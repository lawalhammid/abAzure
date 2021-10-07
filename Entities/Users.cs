using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
namespace AuthenticationApi.Models
{
    public class Users
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key, Column(Order = 0)]
        public long Id { get; set; }
        public string UserType { get; set; }
        public string Channel { get; set; }
        public string FullName { get; set; }
        public string TempaTag { get; set; }
        public string EmailAddress { get; set; }
        [MaxLength(11)]
        public string PhoneNumber { get; set; }
        public byte[] PasswordSalt { get; set; }
        public byte[] PasswordHash { get; set; }
        public string BusinessName { get; set; }
        public string BusinessType { get; set; }
        public string CACRegNo { get; set; }
        public string BusinessTINNumber { get; set; }
        public string BusinessCACDocImageCloudPath { get; set; }
        public string BankName { get; set; }
        public string WalletAcct { get; set; }
        public string WalletAcctName { get; set; }
        [MaxLength(20)]
        public string RegistrationStatus { get; set; }
        public DateTime DateCreated { get; set; }
        public string ReferralCode { get; set; }
        public string GroupName { get; set; }
        public string GroupDescription { get; set; }
        public bool? ReceiveLatestNews { get; set; }
        public string GroupTag { get; set; }
    }
}