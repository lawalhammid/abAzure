using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
namespace AuthenticationApi.Models
{
    public class EmailServer
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key, Column(Order = 0)]
        public int Id { get; set; }
        public string SenderEmail { get; set; }
        public string BodyText { get; set; }
        public string Subject { get; set; }
        public string ServerIP { get; set; }
        public string ServerPassword { get; set; }
        public string SenderType { get; set; }
        public string ServerPort { get; set; }
        public string Remarks { get; set; }
    }
}