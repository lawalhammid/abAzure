using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthenticationApi.ViewModel.Parameters
{
    public class GroupUsersParam 
    {
        public string Channel { get; set; }
        public string TempaTag { get; set; }
        public string EmailAddress { get; set; }
        public string GroupName { get; set; }
        public string GroupTag { get; set; }
        public string GroupDescription { get; set; }
        public string InitiatedBy { get; set; }
    }
}