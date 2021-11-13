using System.Collections.Generic;

namespace app.entity
{
    public class ManProduct
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Url { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        public bool IsApproved { get; set; }
        public bool IsHome { get; set; }        
        public List<Comments> Comments { get; set; }
        public List<ManProductBody> ManProductBodies { get; set; }
        public Persons Persons { get; set; }
        public MansCategory MansCategory { get; set; }
        public MansBrands MansBrands { get; set; }
        

    }
}