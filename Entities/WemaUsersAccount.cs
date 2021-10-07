using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
namespace AuthenticationApi.Models
{
    public class WemaUsersAccount
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key, Column(Order = 0)]
        public long Id { get; set; }
        public string Channel { get; set; }
        public string FullName { get; set; }
        public string TempaTag { get; set; }
        public string EmailAddress { get; set; }
        [MaxLength(11)]
        public string PhoneNumber { get; set; }
        public string BankName { get; set; }
        public string BankAcct { get; set; }
        public string BankAcctName { get; set; }
        public decimal? AmountPerTransaction { get; set; }
        public decimal? AmountPerDay { get; set; }
        public string RegistrationStatus { get; set; }
        public DateTime DateCreated { get; set; }  
    }
}