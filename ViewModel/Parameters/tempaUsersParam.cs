using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthenticationApi.ViewModel.Parameters
{
    public class tempaUsersParam
    {
        public string UserType { get; set; }
        public string Channel { get; set; }
        public string FullName { get; set; }
        public string TempaTag { get; set; }
        public string EmailAddress { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
        public string BankName { get; set; }
        public string BusinessName { get; set; }
        public string BusinessType { get; set; }
        public string CACRegNo { get; set; }
        public string BusinessTINNumber { get; set; }
        public string BusinessCACDocImageCloudPath { get; set; }
        public string GroupName { get; set; }
        public string GroupDescription { get; set; }
        public bool? ReceiveLatestNews { get; set; }
        public string GroupTag { get; set; }
    }
}
