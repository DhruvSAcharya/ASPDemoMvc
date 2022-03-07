using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ASPDemoMvc.Models
{
    public class Registration
    {
      
        [Required]
        public string email { get; set; }

        [Required]
        public string password { get; set; }

        [Required]
        public string confirmpassword { get; set; }

    }
}
