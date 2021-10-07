using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthenticationApi.ViewModel.Parameters
{
    public class AirtimeParam
    {
        public string NetworkType { get; set; }
        public Decimal Amount{ get; set; }
        public decimal AmountToPay{ get; set; }
        public string DrAcct { get; set; }
        public string CrPhoneNo { get; set; }
        public string EmailAddress { get; set; }
        public string Pin { get; set; }
    }

    public class DataParam
    {
        public string NetworkType { get; set; }
        public Decimal Amount { get; set; }
        public decimal AmountToPay { get; set; }
        public string DrAcct { get; set; }
        public string CrPhoneNo { get; set; }
        public string EmailAddress { get; set; }
        public string plan_id { get; set; }
        public string Pin { get; set; }
    }

    public class TransHisByWallet
    {
        public string WalletNo { get; set; }
    }
}
