using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SampleDotNetCoreMVCWithEF.Models
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }

        [Column(TypeName = "nvarchar(250)")]
        [Required(ErrorMessage = "Field can not be blank")]
        public string Name { get; set; }

        [Column(TypeName = "nvarchar(250)")]
        [Required(ErrorMessage = "Field can not be blank")]
        public string Address { get; set; }

        [Column(TypeName = "nvarchar(250)")]
        public string Email { get; set; }

        [Column(TypeName = "nvarchar(250)")]
        public string Mobile { get; set; }
    }
}
