using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace app.entity
{
    public class WomanProduct
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
      
        public int WomansCategoryId { get; set; }
        public WomansCategory WomansCategory { get; set; }
        public int WomansBrandsId { get; set; }
        public WomansBrands WomansBrand { get; set; }
        public List<WomanProductBody> WomanProductBodies { get; set; }
         public int GendersId { get; set; }
        public Genders Genders { get; set; }
    
    }
}