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
    public class UserPinController : ControllerBase// BaseController
    {
        private readonly ILogger<UserPinController> _logger;
        IGenToken _IGenToken;

       IPinSettings _IPinSettings;
        public UserPinController(ILogger<UserPinController> logger, IGenToken IGenToken, IPinSettings IPinSettings)
        {
            _logger = logger;
            _IPinSettings = IPinSettings;
            _IGenToken = IGenToken;
        }
        
        [HttpPost("CreatePin")]
        public async Task<IActionResult> CreatePin(UsersPinParam usersPinParam)
        {
            try
            {
                var res = await _IPinSettings.UsersPin(usersPinParam);

                if (res != null && res.ResponseCode == "00")
                {
                    var token = await _IGenToken.GenNewToken();
                    return Ok(new { res = res, tVal = token });
                }
                return BadRequest(res);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.StackTrace);
                return BadRequest("Invalid Call");
            }
        }

        [HttpPost("ValidatePin")]
        public async Task<IActionResult> ValidatePin(UserPinParam userPinParam)
        {
            try
            {
                var res = await _IPinSettings.ValidatePin(userPinParam);

                if (res != null && res.ResponseCode == "00")
                {
                    var token = await _IGenToken.GenNewToken();
                    return Ok(new { res = res, tVal = token });
                }

                return BadRequest(res);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.StackTrace);
                return BadRequest("Invalid Call");
            }
        }
   
    
    }

}