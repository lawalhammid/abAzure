using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AuthenticationApi.Models
{
    
    public class OnboardActivationDetails
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key, Column(Order = 0)]
        public long Id         { get; set; }
        [MaxLength(6)]
        public string ActivationCode { get; set; }
        public string UserEmail     { get; set; }
        public string Tag { get; set; }
        public DateTime ExpiryDate    { get; set; }
        public DateTime? DateActivated { get; set; }
        public Boolean Activated     { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
