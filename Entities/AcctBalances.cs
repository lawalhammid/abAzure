using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AuthenticationApi.Models
{
    public class AcctBalances
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key, Column(Order = 0)]
        public long Id { get; set; }
        public string TempaTransRef { get; set; }
        public decimal Balance { get; set; }
        public decimal LastAmountCredit { get; set; }
        public string SessionId { get; set; }
        public string EmaiAddress { get; set; }
        public string PhoneNo { get; set; }
        public string TempaBankAcct { get; set; }
        public DateTime DateCreated { get; set; }
    }

}
