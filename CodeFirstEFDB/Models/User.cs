using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace CodeFirstEFDB.Models
{
    public class User
    {
        [Key]
        public int id { get; set; }
        [Required(ErrorMessage = "Name is Required")]
        
        public string Name { get; set; }
        [Range(10, 50)]
        [Required]
        public int Age { get; set; }
        [Required]

        [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$", ErrorMessage = "Please enter a valid e-mail adress")]
        public string EmailAddress { get; set; }
        [Required]
       // [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        public string Password { get; set; }


    }
}