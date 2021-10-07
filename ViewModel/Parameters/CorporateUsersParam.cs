using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthenticationApi.ViewModel.Parameters
{
    public class CorporateUsersParam
    {
        public string Channel { get; set; }
        public string TempaTag { get; set; }
        public string BusinessCACDocImageCloudPath { get; set; }
        public string BusinessName { get; set; }
        public string BusinessTINNumber { get; set; }
        public string BusinessType { get; set; }
    }
}
