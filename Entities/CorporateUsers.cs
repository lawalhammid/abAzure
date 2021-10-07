using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AuthenticationApi.Models
{
    public class CorporateUsers 
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key, Column(Order = 0)]
        public long Id { get; set; }
        public string Channel { get; set; }
        public string Tag { get; set; }
        public string BusinessCACDocImageCloudPath { get; set; }
        public string BusinessName { get; set; }
        public string BusinessTINNumber { get; set; }
        public string BusinessType { get; set; }
        public DateTime DateCreated { get; set; }
        

    }
}
