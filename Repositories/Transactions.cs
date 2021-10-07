using AuthenticationApi.DbContexts;
using AuthenticationApi.DbContexts.Dapper;
using AuthenticationApi.Entities;
using AuthenticationApi.IRepositories;
using AuthenticationApi.Models;
using AuthenticationApi.Utility;
using AuthenticationApi.ViewModel.Parameters;
using AuthenticationApi.ViewModel.Responses;
using AutoMapper;
using Dapper;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthenticationApi.Repositories
{
    public class Transactions: ITransactions
    {
        private readonly TempaAuthContext _dbContext;

        private AppResponse _appResponse = new AppResponse();
        IUnitOfContext _IUnitOfContext;
        private readonly IMapper _mapper;
        private readonly IMsPlug _IMsPlug;
        private readonly IValidateUser _IValidateUser;
        private readonly IEmailSender _IEmailSender;

        public Transactions(TempaAuthContext dbContext, IUnitOfContext IUnitOfContext, IMapper mapper, IMsPlug IMsPlug, IValidateUser IValidateUser, IEmailSender IEmailSender)
        {
            _dbContext = dbContext;
            _IUnitOfContext = IUnitOfContext;
            _mapper = mapper;
            _IMsPlug = IMsPlug;
            _IValidateUser = IValidateUser;
            _IEmailSender = IEmailSender;
        }

        public async Task<string> GetTransRef(string UserType)
        {
            var rtn = new DapperDATAImplementation<TransRef>();

            DynamicParameters param = new DynamicParameters();
            param.Add("@psUserType", UserType);

            var _response = await rtn.ResponseObj("isp_GetTransRef", param);
            if (_response.TransReference != null)
                return _response.TransReference + RandomGeneration.TransConcatenation();
            return null;
        }

        public async Task<decimal> GetUserWalletBalanceByWalletNo(string WalletBankAcct)
        {
            var rtn = new DapperDATAImplementation<WalletResponse>();

            DynamicParameters param = new DynamicParameters();

            param.Add("@WalletBankAcct", WalletBankAcct);

            var _response = await rtn.ResponseObj("isp_GetWalletBalance", param);
            if (_response != null)
                return _response.WalletBalance;

            return Convert.ToDecimal("0.00");
        }

        public async Task<AppResponse> BuyTime(AirtimeParam AirtimeParam, string TransRef)
        {
            try
            {
                string DeviceIdMTNAirtel = "SHIGM89U";
                string DeviceIdGlo  = "MLOKI58";

                string DeviceId = string.Empty;
                string sim_slot = string.Empty;
                if (AirtimeParam.NetworkType.ToLower() == "mtn" || AirtimeParam.NetworkType.ToLower() == "airtel")
                {
                    DeviceId = DeviceIdMTNAirtel;
                    sim_slot = "sim1";
                }
                     
                if (AirtimeParam.NetworkType.ToLower() == "glo")
                {
                    DeviceId = DeviceIdGlo;
                    sim_slot = "sim2";
                }
                   
                var paramBuyAirtim = new MsPlugBuyAirtimeParam
                {
                      network = AirtimeParam.NetworkType, 
                     amount = AirtimeParam.Amount, 
                     phone = AirtimeParam.CrPhoneNo, 
                     device_id = DeviceId, 
                     sim_slot = sim_slot, 
                     airtime_type = "VTU", 
                     webhook_url = "http://www.msplug.com/buyairtime/webhook",
                };

                var buyAirtime = await _IMsPlug.BuyAirtme(paramBuyAirtim);
                if (buyAirtime is not null  && buyAirtime.ResponseTrueOrFalse == true)
                {
                    //Send Email receipt
                    try
                    {
                        var getUser = await _IValidateUser.GetUserDetails(null, null, AirtimeParam.DrAcct);
                        EmailParam emailParam = new EmailParam();
                        emailParam.ReceiverEmail = getUser.EmailAddress;
                        emailParam.FullName = getUser.FullName;


                        getUser.PhoneNumber = AirtimeParam.CrPhoneNo;
                        emailParam.OtherDetails = JsonConvert.SerializeObject(getUser);

                        var emial = await _IEmailSender.SendEmail(emailParam, 3, AirtimeParam.DrAcct, AirtimeParam.CrPhoneNo, AirtimeParam.AmountToPay.ToString(), TransRef, DateTime.Now.ToString());
                    }
                    catch(Exception exSend)
                    {

                    }

                    return new AppResponse
                    {
                        ResponseCode = "00",
                        ResponseMessage = buyAirtime.ResponseMessage
                    };
                }   
            }
            catch (Exception ex)
            {

            }
            return new AppResponse
            {
                ResponseCode = "01",
                ResponseMessage = "You can not buy airtime at this moment, kindly try later"
            }; ;
        }

        public async Task<AppResponse> BuyData(DataParam DataParam)
        {
            try
            {
                string DeviceIdMTNAirtel = "SHIGM89U";
                string DeviceIdGlo = "MLOKI58";

                string DeviceId = string.Empty;
                string sim_slot = string.Empty;
                if (DataParam.NetworkType.ToLower() == "mtn" || DataParam.NetworkType.ToLower() == "airtel")
                {
                    DeviceId = DeviceIdMTNAirtel;
                    sim_slot = "sim1";
                }

                if (DataParam.NetworkType.ToLower() == "glo")
                {
                    DeviceId = DeviceIdGlo;
                    sim_slot = "sim2";
                }

                var paramBuyData  = new MsPlugBuyDataParam
                {
                    network  = DataParam.NetworkType, 
                    plan_id  = DataParam.plan_id, 
                    phone  = DataParam.CrPhoneNo, 
                    device_id  = DeviceId, 
                    sim_slot  = sim_slot, 
                    request_type  = "SMS",
                    webhook_url  = ""
                };

                var buyAirtime = await _IMsPlug.BuyData(paramBuyData);
                if (buyAirtime is not null && buyAirtime.ResponseTrueOrFalse == true)
                {
                    //Send Email receipt
                    try
                    {
                        var getUser = await _IValidateUser.GetUserDetails(null, null, DataParam.DrAcct);
                        EmailParam emailParam = new EmailParam();
                        emailParam.ReceiverEmail = getUser.EmailAddress;
                        emailParam.FullName = getUser.FullName;
                        emailParam.OtherDetails = JsonConvert.SerializeObject(getUser);

                        var emial = await _IEmailSender.SendEmail(emailParam, 3);
                    }
                    catch (Exception exSend)
                    {

                    }

                    return new AppResponse
                    {
                        ResponseCode = "00",
                        ResponseMessage = "Your  request was successful!"
                    };
                }
            }
            catch (Exception ex)
            {

            }
            return new AppResponse
            {
                ResponseCode = "01",
                ResponseMessage = "You can not buy airtime at this moment, kindly try later"
            }; ;
        }

        public async Task<TransactionLog> InsertTransaction(TransactionLogParam transactionLogParam)
        {
            var transactionLog = new TransactionLog();// _mapper.Map<TransactionLog>(transactionLogParam);

            transactionLog.DrAcct =   transactionLogParam.DrAcct;
            transactionLog.CrAcct = transactionLogParam.CrAcct;
            transactionLog.Amount = transactionLogParam.Amount;
            transactionLog.AmountToPay = transactionLogParam.AmountToPay;
            transactionLog.Naration = transactionLogParam.Naration;
            transactionLog.TransferType = transactionLogParam.TransferType;
            transactionLog.TempaTransRef = await GetTransRef("Individual") + RandomGeneration.TransConcatenation();
            transactionLog.TransDate = DateTime.Now;
            transactionLog.Status = transactionLogParam.Status;

            await _dbContext.AddAsync(transactionLog);
            int save = await _IUnitOfContext.Save();
            if (save > 0)
                return transactionLog;
            return null;
        }
        public async Task<AppResponse> UpateTransaction(TransactionLog TransactionLog, bool TransStatus)
        {


            TransactionLog.TransCompleteDate  = DateTime.Now;
            TransactionLog.Status = TransStatus == true ? "Success" : "Failed";

             _dbContext.Update(TransactionLog);
            int save = await _IUnitOfContext.SaveAuditTrail(TransactionLog.DrAcct);
            if (save > 0)
                return new AppResponse
                {
                    ResponseCode = "00",
                    ResponseMessage = "Transaction Successful!"
                };
            return null;
        }

        public async Task<ResponseWallet> UpdateBalanceForWallet(TransactionLogParam TransactionLogParam, string TempaTransRef, long TransactionlogId, string ApproveBy)
        {
            var rtn = new DapperDATAImplementation<ResponseWallet>();

            DynamicParameters param = new DynamicParameters();

            param.Add("@TempaTransRef", TempaTransRef);
            param.Add("@LastAmountCredit", TransactionLogParam.Amount);
            param.Add("@SessionId", null);
            param.Add("@EmaiAddress", null); // hard code will later look where to pass it
            param.Add("@PhoneNo", null); // hard code will later look where to pass it
            param.Add("@TempaBankAcct", TransactionLogParam.DrAcct);
            param.Add("@DrAcct", TransactionLogParam.DrAcct);
            param.Add("@CrAcct", TransactionLogParam.CrAcct);
            param.Add("@DrAcctName", TransactionLogParam.DrAcctName);
            param.Add("@CrAcctName", "AbzWorld and Tarmac Acct");
            param.Add("@BankCode", null);
            param.Add("@BankName", "AbzWorld");
            param.Add("@Narration", TransactionLogParam.Naration);
            param.Add("@PamymentReference", TempaTransRef);
            param.Add("@TransactionlogId", TransactionlogId);
            param.Add("@ApproveBy", ApproveBy);

            var _response = await rtn.ResponseObj("isp_UpdateWalletToWallet", param);

            return _response;
        }


        public async Task<AppResponse> InsertErrorUpdateWalletBalance(ErrorUpdateWalletBalance ErrorUpdateWalletBalance)
        {
            var  errTb = new ErrorUpdateWalletBalance();// _mapper.Map<TransactionLog>(transactionLogParam);
            ErrorUpdateWalletBalance.DateCreated = DateTime.Now;


            await _dbContext.AddAsync(errTb);
            int save = await _IUnitOfContext.Save();
            if (save > 0)
                return new AppResponse { 
                    ResponseCode = "00",
                    ResponseMessage = "Success"
                };

            return null;
        }

        public async Task<IEnumerable<TransHisResponse>> GetTransHisByWallet(string WalletAcct)
        {
            var rtn = new DapperDATAImplementation<TransHisResponse>();

            DynamicParameters param = new DynamicParameters();

            param.Add("@psWalletAcct", WalletAcct);
            var _response = await rtn.LoadData("tarMac_GetTransHis", param);

            return _response;
        }
    }
}
