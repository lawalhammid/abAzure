using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthenticationApi.ViewModel.Parameters
{
    public class LoginParam
    {
        public string UserEmailOrPhone  { get; set; }
        public string  Password { get; set; }
        
    }

    public class LoginFingerPrintParam
    {
        public string Value { get; set; }


    }

    public class LoginDetails
    {
        public string AcctNo { get; set; }


    }

    //0012210910
}
