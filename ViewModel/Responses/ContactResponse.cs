using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthenticationApi.ViewModel.Responses
{
    public class ContactResponse
    {
        public string FullName { get; set; }
        public string TempaTag { get; set; }
        public string PhoneNumber { get; set; }
        public string BankAcct { get; set; }
    }

    public class ContactResponse1
    {
        
        public string Select { get; set; }
    }

    public class ResponseBalanceOnBoard
    {

        public string ResponseCode { get; set; }
        public string status { get; set; }
    }
}
