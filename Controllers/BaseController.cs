using AuthenticationApi.ViewModel.Responses;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthenticationApi.Controllers
{
    public class BaseController : ControllerBase
    {
        //public BaseController()
        //{
        //}
        public IActionResult ReturnBadRequest(AppResponse appResponse)
        {
            return BadRequest(new
            {
                ResponseCode = appResponse.ResponseCode,
                ResponseMessage = appResponse.ResponseMessage,
            });
        }

        public IActionResult ReturnBadRequest(string message, string code = null)
        {
            return BadRequest(new AppResponse
            {
                ResponseMessage = message,
                ResponseCode = code ?? "401",

            });
        }
    }
}
