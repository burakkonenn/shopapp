using System.Collections.Generic;

namespace app.entity
{
    public class Cart
    {
        public int Id { get; set; }
        public string UserId { get; set; }
         public string Url { get; set; }
        public List<CartItem> CartItems { get; set; }
        
        
        
    }
}