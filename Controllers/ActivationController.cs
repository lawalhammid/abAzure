using AuthenticationApi.IRepositories;
using AuthenticationApi.Models;
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
    public class ActivationController : ControllerBase //BaseController
    {
        IToken _IToken;
        IGenToken _IGenToken;
        IOnboardActivation _IOnboardActivation;
        // private readonly ILogger<LoginController> _logger;
        //,(ILogger<LoginController> logger,
        public ActivationController(IToken IToken, IGenToken IGenToken, IOnboardActivation IOnboardActivation)
        {
            _IToken = IToken;
            _IGenToken = IGenToken;
            _IOnboardActivation = IOnboardActivation;
        }
       
  

        [HttpPost("Activate")]
        public async Task<IActionResult> Activate(ActivationParam activationParam)
        {
            try
            {
                var res = await _IOnboardActivation.ActivateWEMA(activationParam);

                if (!string.IsNullOrWhiteSpace(res.ResponseCode) && res.ResponseCode == "00")
                {
                    var token = await _IGenToken.GenNewToken();
                    return Ok(new { tVal = token, res = res });
                }
                else
                {
                    return BadRequest(new { res = res });
                }
                return BadRequest("Invalid Call");
            }
            catch (Exception ex)
            {
                //logger.Log(ex.StackTrace);
                //this._logger.LogError(ex.StackTrace);
                // this._logger.LogTrace(ex.StackTrace);
                return BadRequest("Invalid Call");
            }


        }
        [HttpPost("ReActivate")]
        public async Task<IActionResult> ReActivate(ActivationParam activationParam)
        {
            try
            {
                var res = await _IOnboardActivation.ReActivateWEMA(activationParam);

                if (!string.IsNullOrWhiteSpace(res.ResponseCode) && res.ResponseCode == "00")
                {
                    var token = await _IGenToken.GenNewToken();
                    return Ok(new { tVal = token, res = res });
                }
                else
                {
                    return BadRequest(new { res = res });
                }
                return BadRequest("Invalid Call");
            }
            catch (Exception ex)
            {
                //logger.Log(ex.StackTrace);
                //this._logger.LogError(ex.StackTrace);
                // this._logger.LogTrace(ex.StackTrace);
                return BadRequest("Invalid Call");
            }


        }



    }
}   