using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthenticationApi.ViewModel.Parameters
{
    public class EmailParam
    {
        public string SenderEmail { get; set; }
        public string  ReceiverEmail { get; set; }
        public string BodyText { get; set; }
        public string ServerIP { get; set; }
        public string ServerPassword { get; set; }
        public string ServerPort { get; set; }
        public string FullName { get; set; }
        public string Pin { get; set; }
        public string OtherDetails { get; set; }
    }
}
