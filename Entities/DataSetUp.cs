using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AuthenticationApi.Models
{
    public class DataSetUp
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key, Column(Order = 0)]
        public long Id { get; set; }
        public string ServiceProvider { get; set; }
        public string PlanId { get; set; }
        public string DeviceId { get; set; }
        public string SimSlot { get; set; }
        public string RequestType { get; set; }
        public decimal AmountToDisplay { get; set; }
        public decimal AmountToSendToServiceProvider { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
