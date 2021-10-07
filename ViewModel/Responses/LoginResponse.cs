using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthenticationApi.ViewModel.Responses
{
    public class LoginResponse
    {
        public string ResponseCode { get; set; }
        public string ResponseMessage { get; set; }
        public string UserAccount { get; set; }
        public string BankName { get; set; }
        public string UserFullName { get; set; }
        public string UserType { get; set; }
        public string TempaTag { get; set; }
        public string GroupTag { get; set; }
        public string OtherDetails { get; set; }
        public LoginUserResponse loginUserResponse { get; set; }
    }

    public class LoginUserResponse
    {
        public string UserType { get; set; }
        public string FullName { get; set; }
        public string TempaTag { get; set; }
        public string EmailAddress { get; set; }
        public string PhoneNumber { get; set; }
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