using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AuthenticationApi.ViewModel.Parameters
{

    public class WemaUsersAccountParam
    {
        public long Id { get; set; }
        public string Channel { get; set; }
        public string FullName { get; set; }
        public string TempaTag { get; set; }
        public string EmailAddress { get; set; }
        [MaxLength(11)]
        public string PhoneNumber { get; set; }
        public string BankName { get; set; }
        public string BankAcct { get; set; }
        public string BankAcctName { get; set; }
        public string RegistrationStatus { get; set; }
        public DateTime? DateCreated { get; set; }

    }

    public class WemaValidateUsersAccountParam
    {
        public string AcctountNumber { get; set; }
        public string BankCode { get; set; }
        
    }

    public class WemaValidateUsersAmountValidationParam
    {
        public string AccountNumber { get; set; }
        public decimal? Amount { get; set; }
        
    }

}
