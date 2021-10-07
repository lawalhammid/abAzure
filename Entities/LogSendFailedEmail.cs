using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AuthenticationApi.Models
{
    //Would use this class
    public class LogSendFailedEmail
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key, Column(Order = 0)]
        public long Id { get; set; }
        public string Subject { get; set; }
        public string MailBody { get; set; }
        public string ReceiverEmail { get; set; }
        public string SenderEmail { get; set; }
        public string Status { get; set; }
        public int ServerId { get; set; }
    }
}
