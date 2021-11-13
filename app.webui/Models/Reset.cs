using System.ComponentModel.DataAnnotations;

namespace app.webui.Models
{
    public class Reset
    {
       [Required]
        public string Token { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        
        
        
        
        
        
    }
}