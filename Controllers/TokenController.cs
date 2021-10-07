using AuthenticationApi.IRepositories;
using AuthenticationApi.Models;
using AuthenticationApi.ViewModel;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using AuthenticationApi.ApiCalls;
using AuthenticationApi.ViewModel.Parameters;
using Newtonsoft.Json;
using AuthenticationApi.Utility;
using AuthenticationApi.ViewModel.Responses;

namespace AuthenticationApi.Controllers
{
    [ApiController]
    [Route("Abtarmac/v1/[controller]")]
    [EnableCors("cors")]
    public class TokenController : ControllerBase//, BaseController
    {
        IToken _IToken;
        IGenToken _IGenToken;
        ILogTBL _ILogTBL;
        //ILogger<TokenController> _logger;
        //ILogger<TokenController> logger
        public TokenController( IToken IToken, IGenToken IGenToken, ILogTBL ILogTBL)
        {
            _IToken = IToken;
            _IGenToken = IGenToken;
            _ILogTBL = ILogTBL;
           //_logger = logger;
        }
        /* tVal means token  */    
        [HttpPost]      
        public async Task<IActionResult> GetToken(GetTokenParam getTokenParam)
        {
            try
            {
                var res = await _IToken.validate(getTokenParam);

                if (!string.IsNullOrWhiteSpace(res.Token))
                {
                    
                    var token = await _IGenToken.GenNewToken();
                    return Ok(new { tVal = token, GetC = AppSettingsConfig.GetControllerToUse() });
                }
                return BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
    }
}