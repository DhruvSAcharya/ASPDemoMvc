using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ASPDemoMvc.Models
{
    public class UsersModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string emailid { get; set; }

        [Required]
        public string password { get; set; }
    }
}
