using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AuthenticationApi.Models
{
    public class AuditTrail
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key, Column(Order = 0)]
        public long Id { get; set; }
        public string EmailOrUserid { get; set; }
        public DateTime Eventdateutc { get; set; }
        public string Eventtype { get; set; }
        public string Tablename { get; set; }
        public string Recordid { get; set; }
        public string Originalvalue { get; set; }
        public string Newvalue { get; set; }
    }


}
