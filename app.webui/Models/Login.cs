using System.ComponentModel.DataAnnotations;

namespace app.webui.Models
{
    public class Login
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        // public string UserName { get; set; }
        public string Eposta { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Sifre { get; set; }
        public string ReturnUrl { get; set; }
    }
}