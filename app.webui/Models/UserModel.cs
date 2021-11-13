using System.Collections.Generic;

namespace app.webui.Models
{
    public class UserModel
    {
        public string userId { get; set; }
        public string Username { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public IEnumerable<string> SelectedRoles { get; set; }
        
        
        
        
        
        
        
        
    }
}