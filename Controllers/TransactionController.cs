using Ardalis.GuardClauses;
using AuthenticationApi.Entities;
using AuthenticationApi.IRepositories;
using AuthenticationApi.Models;
using AuthenticationApi.Repositories;
using AuthenticationApi.Utility;
using AuthenticationApi.ViewModel;
using AuthenticationApi.ViewModel.Parameters;
using AuthenticationApi.ViewModel.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthenticationApi.Controllers
{
    [Produces("application/json")]
    //[Authorize(AuthenticationSchemes = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme)]
    [Route("Abtarmac/v1/[controller]")]
    [ApiController]
    [EnableCors("cors")]
    public class TransactionController : ControllerBase //BaseController
    {
        private readonly IToken _IToken;
        private readonly IGenToken _IGenToken;
        private readonly IOnboardActivation _IOnboardActivation;
        private readonly ITransactions _ITransactions;
        private readonly IMsPlug _IMsPlug;
        private readonly IPinSettings _IPinSettings;
        private readonly ILogger<LoginController> _logger;
        //,(ILogger<LoginController> logger,
        public TransactionController(ILogger<LoginController> logger, IToken IToken, IGenToken IGenToken, IOnboardActivation IOnboardActivation, ITransactions ITransactions, IMsPlug IMsPlug, IPinSettings IPinSettings)
        {
            _IToken = IToken;
            _IGenToken = IGenToken;
            _IOnboardActivation = IOnboardActivation;
            _ITransactions = ITransactions;
            _IMsPlug = IMsPlug;
            _IPinSettings = IPinSettings;
            _logger = logger;
        }

        [HttpPost("GetBalances")]
        public async Task<IActionResult> GetBalances(GetBalance getBalance)
        {
                try
                {
                var getBal = await _ITransactions.GetUserWalletBalanceByWalletNo(getBalance.WalletNo);

                if (getBal != null)
                {
                    var token = await _IGenToken.GenNewToken();
                    string BalanceWithComma = Formatter.FormattedAmount(getBal);
                    return Ok(new { Balance = BalanceWithComma, tVal = token });
                }
                return BadRequest("Invalid Call");
            }
            catch (Exception ex)
            {
                //_logger.LogError(ex.StackTrace);
                return BadRequest("Invalid Call");
            }
        }

        /*======= MsPlug Services below*/

        [HttpPost("GetDataPlan")]
        public async Task<IActionResult> GetDataPlan(AirtimeParam AirtimeParam)
        {
            try
            {
                var res = _IMsPlug.GetDataPlan();

                if (res != null)
                {
                    var token = await _IGenToken.GenNewToken();
                 
                     return Ok(new { res = res, tVal = token });
                }
                return BadRequest("Invalid Call");
            }
            catch (Exception ex)
            {
                //_logger.LogError(ex.StackTrace);
                return BadRequest("Invalid Call");
            }
        }

        [HttpPost("BuyAirtime")]
        public async Task<IActionResult> BuyAirtime(AirtimeParam AirtimeParam)
        {
            //------- To use Guard below for your validation, firstly download it from nuget then use it as below
            try
            {
                AirtimeParam.Amount = Guard.Against.NegativeOrZero(AirtimeParam.Amount, nameof(AirtimeParam.Amount));
                AirtimeParam.AmountToPay = Guard.Against.NegativeOrZero(AirtimeParam.AmountToPay, nameof(AirtimeParam.AmountToPay));
                AirtimeParam.CrPhoneNo = Guard.Against.NullOrWhiteSpace(AirtimeParam.CrPhoneNo, nameof(AirtimeParam.CrPhoneNo));
            }
            catch (Exception excValidation)
            {
                return BadRequest(excValidation.Message);
            }

            try
            {
                UserPinParam userPinParam = new UserPinParam();
                userPinParam.EmailAddress = AirtimeParam.EmailAddress;
                userPinParam.Pin = AirtimeParam.Pin;
                var PinVal = await _IPinSettings.ValidatePin(userPinParam);
                if(PinVal.ResponseCode != "00")
                {
                    return BadRequest(PinVal);
                }

                var getBal = await _ITransactions.GetUserWalletBalanceByWalletNo(AirtimeParam.DrAcct);
               
                if(getBal < 0)
                {
                    var res = new AppResponse()
                    {
                        ResponseCode = "01",
                        ResponseMessage = "Insufficient Balance! Kindly fund your wallet."
                    };

                    return BadRequest(new { res = res });
                    
                }

                TransactionLogParam transactionLogParam = new TransactionLogParam();
                
                transactionLogParam.DrAcct = AirtimeParam.DrAcct;
                transactionLogParam.CrAcct = AirtimeParam.CrPhoneNo;
                transactionLogParam.Amount = AirtimeParam.Amount;
                transactionLogParam.AmountToPay = AirtimeParam.AmountToPay;
                transactionLogParam.Naration = $"Buy Airtime of {AirtimeParam.Amount} for {AirtimeParam.CrPhoneNo}";
                transactionLogParam.TransferType = "Airtime";
                transactionLogParam.Status = "Pending";

                var ins = await _ITransactions.InsertTransaction(transactionLogParam);
                
                if(ins is not null)
                {
                    var buyData = await _ITransactions.BuyTime(AirtimeParam, ins.TempaTransRef);

                    if (buyData is not null && buyData.ResponseCode == "00")
                    {
                        string abTarmacAcct = "0010000000";  //this would be taken to appsettings later. this is tempa account used like GL account

                        //update wallet by reducing dr wallet acct and cr wallet acc
                        TransactionLogParam TransactionLogParam = new TransactionLogParam();

                        TransactionLogParam.DrAcct = AirtimeParam.DrAcct;
                        TransactionLogParam.CrAcct = abTarmacAcct;
                        TransactionLogParam.Amount = AirtimeParam.AmountToPay;
                        TransactionLogParam.TransResponseDescription = "Success. Note I hard coded this for now"; // buyData.ResponseMessage;

                        var updateWallet = await _ITransactions.UpdateBalanceForWallet(TransactionLogParam, ins.TempaTransRef, ins.TId);

                        if(updateWallet.ResponseCode != 0)
                        {
                            var errTba = new ErrorUpdateWalletBalance();
                            errTba.DrAcct = AirtimeParam.DrAcct;
                            errTba.CrAcct = abTarmacAcct;
                            errTba.Amount = AirtimeParam.Amount;
                            errTba.Status = "Pending";

                            var insErr = _ITransactions.InsertErrorUpdateWalletBalance(errTba);
                        }
                      
                        //update Trans Table
                        bool transStatus = buyData.ResponseCode == "00" ? true : false;

                        transactionLogParam.TransResponsecode = buyData.ResponseMessage;
                        ins.Status = "Success";
                        ins.TransCompleteDate = DateTime.Now;
                        var update =  await _ITransactions.UpateTransaction(ins, transStatus);

                        var token = await _IGenToken.GenNewToken();

                        return Ok(new { res = update, tVal = token });
                    }
                    return BadRequest(new { res = buyData } );
                }
              
                return BadRequest("Invalid Call");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.StackTrace);
                return BadRequest("Invalid Call");
            }
        }

        [HttpPost("BuyData")]
        public async Task<IActionResult> BuyData(DataParam buyDataParam)
        {
            //------- To use Guard below for your validation, firstly download it from nuget then use it as below
            try
            {
                buyDataParam.Amount = Guard.Against.NegativeOrZero(buyDataParam.Amount, nameof(buyDataParam.Amount));
                buyDataParam.CrPhoneNo = Guard.Against.NullOrWhiteSpace(buyDataParam.CrPhoneNo, nameof(buyDataParam.CrPhoneNo));
            }
            catch (Exception excValidation)
            {
                return BadRequest(excValidation.Message);
            }

            try
            {
                UserPinParam userPinParam = new UserPinParam();
                userPinParam.EmailAddress = buyDataParam.EmailAddress;
                userPinParam.Pin = buyDataParam.Pin;
                var PinVal = await _IPinSettings.ValidatePin(userPinParam);
                if (PinVal.ResponseCode != "00")
                {
                    return BadRequest(PinVal);
                }

                TransactionLogParam transactionLogParam = new TransactionLogParam();

                transactionLogParam.DrAcct = buyDataParam.DrAcct;
                transactionLogParam.CrAcct = buyDataParam.CrPhoneNo;
                transactionLogParam.Amount = buyDataParam.Amount;
                transactionLogParam.Naration = "Buy Data";
                transactionLogParam.TransferType = "Data";

                var ins = await _ITransactions.InsertTransaction(transactionLogParam);

                if (ins is not null)
                {
                    var buyData = await _ITransactions.BuyData(buyDataParam);
                    if (buyData is not null && buyData.ResponseCode == "00")
                    {
                        string abTarmacAcct = "0010000000";  //this would be taken to appsettings later. this is tempa account used like GL account

                        //update wallet by reducing dr wallet acct and cr wallet acc
                        TransactionLogParam TransactionLogParam = new TransactionLogParam();
                        TransactionLogParam.CrAcct = abTarmacAcct;

                        var updateWallet = await _ITransactions.UpdateBalanceForWallet(TransactionLogParam, ins.TempaTransRef, ins.TId);
                        if (updateWallet.ResponseCode != 0)
                        {
                            var errTba = new ErrorUpdateWalletBalance();
                            errTba.DrAcct = buyDataParam.DrAcct;
                            errTba.CrAcct = abTarmacAcct;
                            errTba.Amount = buyDataParam.Amount;
                            errTba.Status = "Pending";

                            var insErr = _ITransactions.InsertErrorUpdateWalletBalance(errTba);
                        }

                        //update Trans Table
                        bool transStatus = buyData.ResponseCode == "00" ? true : false;

                        transactionLogParam.TransResponsecode = buyData.ResponseMessage;

                        var update = await _ITransactions.UpateTransaction(ins, transStatus);

                        var token = await _IGenToken.GenNewToken();

                        return Ok(new { res = update, tVal = token });
                    }
                }
                return BadRequest("Invalid Call");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.StackTrace);
                return BadRequest("Invalid Call");
            }
        }

        [HttpPost("TransHisByWalltet")]
        public async Task<IActionResult> TransHisByWalltet(TransHisByWallet TransHisByWallet)
        {
            //------- To use Guard below for your validation, firstly download it from nuget then use it as below
            try
            {
              
                TransHisByWallet.WalletNo  = Guard.Against.NullOrWhiteSpace(TransHisByWallet.WalletNo, nameof(TransHisByWallet.WalletNo));
            }
            catch (Exception excValidation)
            {
                return BadRequest(excValidation.Message);
            }
            try
            {

                var getHis = await _ITransactions.GetTransHisByWallet(TransHisByWallet.WalletNo);
                if(getHis.Count() > 0)
                {
                    return Ok(new { res = getHis });
                }
                return BadRequest("Invalid Call");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.StackTrace);
                return BadRequest("Invalid Call");
            }
        }
       
        /*======= MsPlug Services ends here*/
    }
}   