using AuthenticationApi.ApiCalls;
using AuthenticationApi.IRepositories;
using AuthenticationApi.Models;
using AuthenticationApi.Utility;
using AuthenticationApi.ViewModel;
using AuthenticationApi.ViewModel.Parameters;
using AuthenticationApi.ViewModel.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
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
    public class ContactsController : ControllerBase//BaseController
    {
        IGenToken _IGenToken;
        ILogTBL _ILogTBL;
        IUsers _ItempaUsers;
        private readonly ILogger<RegUserController> _logger;
        public ContactsController(ILogger<RegUserController> logger, IToken IToken, IGenToken IGenToken, ILogTBL ILogTBL, IUsers ItempaUsers)
        {

            _IGenToken = IGenToken;
            _ILogTBL = ILogTBL;
            _ItempaUsers = ItempaUsers;
            _logger = logger;
        }

        [HttpPost("Contact")]
        public async Task<IActionResult> CreateTempaUserProvidus(ContactParam ContactParam)
        {
            try
            {
                var res = await _ItempaUsers.Contacts(ContactParam);
               
                if(res.Count > 0)
                {
                    var token = await _IGenToken.GenNewToken();
                    return Ok(new { tVal = token, res = res });
                }
                
                return BadRequest(new { res = res });
            }
            catch(Exception ex)
            {
                
                _logger.LogError(ex.StackTrace);

                return this.BadRequest("Invalid Call");
            } 
        }
    }
}