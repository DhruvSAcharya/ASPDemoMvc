using System.ComponentModel.DataAnnotations;

namespace ASPDemoMvc.Models
{
    public class ServiceRequest
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string fName { get; set; }
        [Required]
        public string lName { get; set; }
        [Required]
        public string mobileNo { get; set; }
        [Required]
        public string email { get; set; }
        [Required]
        public string enquiryPurpose { get; set; }
        [Required]
        public string comments { get; set; }
        public int userid { get; set; }

    }
}
