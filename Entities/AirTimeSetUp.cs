using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AuthenticationApi.Models
{
    public class AirTimeSetUp 
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key, Column(Order = 0)]
        public long Id { get; set; }
        public string ServiceProvider { get; set; }
        public decimal AmountToDisplay { get; set; }
        public decimal AmountToSendToServiceProvider { get; set; }
        public DateTime DateCreated { get; set; }
    }

}
