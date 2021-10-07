using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthenticationApi.ViewModel.Parameters
{
    public class MsPlugBuyAirtimeParam
    {
        public string network { get; set; } 
        public Decimal amount { get; set; } 
        public string phone { get; set; } 
        public string device_id { get; set; } 
        public string sim_slot { get; set; } 
        public string airtime_type { get; set; } 
        public string webhook_url { get; set; }       
  }

    public class MsPlugBuyDataParam
    {
        public string network { get; set; }
        public string plan_id { get; set; }
        public string phone { get; set; }
        public string device_id { get; set; }
        public string sim_slot { get; set; }
        public string request_type { get; set; } = "SMS";
        public string webhook_url { get; set; }
    }
    
}
