using AuthenticationApi.IRepositories;
using AuthenticationApi.Models;
using AuthenticationApi.Repositories;
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
    public class TarmacController : ControllerBase //BaseController
    {
        IToken _IToken;
        IGenToken _IGenToken;
        IOnboardActivation _IOnboardActivation;
        ITransactions _ITransactions;
        // private readonly ILogger<LoginController> _logger;
        //,(ILogger<LoginController> logger,
        public TarmacController(IToken IToken, IGenToken IGenToken, IOnboardActivation IOnboardActivation, ITransactions ITransactions)
        {
            _IToken = IToken;
            _IGenToken = IGenToken;
            _IOnboardActivation = IOnboardActivation;
            _ITransactions = ITransactions;
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
    }
}   