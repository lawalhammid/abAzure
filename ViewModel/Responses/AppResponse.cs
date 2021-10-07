using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthenticationApi.ViewModel.Responses
{
    public class AppResponse
    {
        public string ResponseCode { get; set; }
        public bool ResponseTrueOrFalse  { get; set; }
        public string ResponseMessage { get; set; }
    }

    public class TransRef
    {
        public string TransReference { get; set; }
    }

    public class WalletResponse
    {
        public decimal WalletBalance { get; set; }
    }

    public class ResponseWallet
    {
        public int ResponseCode { get; set; }
        public string status { get; set; }
    }
}