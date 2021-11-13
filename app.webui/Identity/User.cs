using Microsoft.AspNetCore.Identity;

namespace app.webui.Identity
{
    public class User: IdentityUser
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
    }
}