using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthenticationApi.ViewModel.Responses
{
    public class MsPlugGetDataPlanResponse
    {
        public int plan_id { get; set; } 
        public int id { get; set; } 
        public string network { get; set; }
        public string plan_size { get; set; }
        public string plan_type { get; set; }
        public string month_validate { get; set; }
        public string ussd_string { get; set; }
        public string sms_command { get; set; }
    }
}
