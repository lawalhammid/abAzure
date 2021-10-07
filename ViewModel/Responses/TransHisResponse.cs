using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthenticationApi.ViewModel.Responses
{
    public class TransHisResponse
    {
        public string DrAcct { get; set; }
        public string CrAcct { get; set; }
        public string Amount { get; set; }
        public string TransDate { get; set; }
        public string Naration { get; set; }
        public string TransferType { get; set; }
        public string TempaTransRef { get; set; }
        public string Status { get; set; }
    }
}
