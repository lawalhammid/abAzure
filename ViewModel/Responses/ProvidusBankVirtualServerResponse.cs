using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthenticationApi.ViewModel.Responses
{
    public class ProvidusBankVirtualServerResponse
    {
        public string UrlAcctCreation { get; set; }
        public string ClientId { get; set; }
        public string XAuthSign { get; set; }
       
    }
}
