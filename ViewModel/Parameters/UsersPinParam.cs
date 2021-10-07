using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthenticationApi.ViewModel.Parameters
{
    public class UsersPinParam
    {
        public string Channel { get; set; }
       // public string TempaTag { get; set; }
        public string EmailAddress { get; set; }
        public string Pin { get; set; }
    }

    public class UserPinParam
    {
        public string EmailAddress { get; set; }
        public string Pin { get; set; }
    }
}
