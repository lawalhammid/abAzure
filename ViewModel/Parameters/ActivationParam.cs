using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthenticationApi.ViewModel.Parameters
{
    public class ActivationParam
    {
        public string ActivationCode { get; set; }
        public string  UserEmail { get; set; }
        
    }
}
