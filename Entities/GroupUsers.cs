using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AuthenticationApi.Models
{
    public class GroupUsers
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key, Column(Order = 0)]
        public long Id { get; set; }
        public string Channel { get; set; }
        public string Tag { get; set; }
        public string GroupName { get; set; }
        public string GroupTag { get; set; }
        public string GroupDescription { get; set; }
        public string InitiatedBy { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
