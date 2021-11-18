using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using app.webui.Identity;

namespace app.webui.Models
{
    public class UserModelManage
    {
        public IEnumerable<User> User { get; set; }
        public string Username { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public bool IsEmailConfirm { get; set; }
        
 
    }
}