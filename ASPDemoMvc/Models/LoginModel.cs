using System.ComponentModel.DataAnnotations;

namespace ASPDemoMvc.Models
{
    public class LoginModel
    {
        [Required]
        public string email { get; set; }

        [Required]
        public string password { get; set; }
    }
}
