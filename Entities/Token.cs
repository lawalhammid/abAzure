using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AuthenticationApi.Models
{
    public class Token
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public long value1 { get; set; }
        public string  value2 { get; set; }
    }
}
