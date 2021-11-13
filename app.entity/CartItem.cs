namespace app.entity
{
    public class CartItem
    {
        public int Id { get; set; }
        public int CartId { get; set; }
        public Cart Cart { get; set; }

        public ManProduct ManProduct { get; set; }
        public int ManProductId { get; set; }
        
        public int Quantity { get; set; }

        public WomanProduct WomanProduct { get; set; }
        public int WomanProductId { get; set; }
        
        
        
    }
}