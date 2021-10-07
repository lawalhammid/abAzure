using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthenticationApi.ViewModel.Responses
{
    public class ProvidusBankCredentialResponse
    {
        public string EndPoint { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
