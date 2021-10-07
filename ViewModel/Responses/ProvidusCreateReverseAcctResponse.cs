using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthenticationApi.ViewModel.Responses
{
    public class ProvidusCreateReverseAcctResponse
    {

        public string account_number { get; set; }
        public string account_name { get; set; }
        public string bvn { get; set; }
        public bool requestSuccessful { get; set; }
        public string responseMessage { get; set; }
        public string responseCode { get; set; }

    }
}







