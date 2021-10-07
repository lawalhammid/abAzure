using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthenticationApi.Repositories
{
    public class GetBalance
    {
        public string WalletNo { get; set; }
    }

    public class GetCharges
    {
        public decimal? transAmount { get; set; }
    }
}
