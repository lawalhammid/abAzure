using AuthenticationApi.IRepositories;
using AuthenticationApi.Models;
using AuthenticationApi.Utility;
using AuthenticationApi.ViewModel;
using AuthenticationApi.ViewModel.Parameters;
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
    public class LoginController : ControllerBase //BaseController
    {
        IToken _IToken;
        IGenToken _IGenToken;
        ILogTBL _ILogTBL;
        IUsers _ItempaUsers;
        ITransactions _ITransactions;
        // private readonly ILogger<LoginController> _logger;
        //,(ILogger<LoginController> logger,
        public LoginController(IToken IToken, IGenToken IGenToken, ILogTBL ILogTBL, IUsers ItempaUsers, ITransactions ITransactions)
        {
            _IToken = IToken;
            _IGenToken = IGenToken;
            _ILogTBL = ILogTBL;
            _ItempaUsers = ItempaUsers;
            _ITransactions = ITransactions;
           // this._logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> Post(LoginParam loginParam)
        {
            try
            {
                var res = await _ItempaUsers.LoginUser(loginParam);

                if (res != null && res.ResponseCode == "00")
                {
                    decimal getBal = 0;
                    try
                    {
                         getBal = await _ITransactions.GetUserWalletBalanceByWalletNo(res.UserAccount);

                        
                    }
                    catch (Exception exc)
                    {

                    }
                    string bal = Formatter.FormattedAmount(getBal);
                    var token = await _IGenToken.GenNewToken();
                    return Ok(new { res = res, getBal = bal, tVal = token });
                }
                return BadRequest(new { res = res });
            }
            catch (Exception ex)
            {
                //logger.Log(ex.StackTrace);
                //this._logger.LogError(ex.StackTrace);
                // this._logger.LogTrace(ex.StackTrace);
                return BadRequest("Invalid Call");
            }
            //return this.BadRequest("Invalid Call");
        }


        [HttpPost("Verify")]
        public async Task<IActionResult> Verify(LoginDetails loginDetails)
        {
            try
            {
                var res = await _ItempaUsers.VeryUserByAcctNo(loginDetails.AcctNo);

                if (res != null)
                {

                    var token = await _IGenToken.GenNewToken();
                    return Ok(new { res = res, tVal = token });
                }
                return BadRequest("Invalid User");
            }
            catch (Exception ex)
            {
                var exM = ex.StackTrace;
                //logger.Log(ex.StackTrace);
                //this._logger.LogError(ex.StackTrace);
                // this._logger.LogTrace(ex.StackTrace);
                return BadRequest("Invalid Call");
            }
            //return this.BadRequest("Invalid Call");
        }
    }
}