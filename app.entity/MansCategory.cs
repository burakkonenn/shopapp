using System.Collections.Generic;

namespace app.entity
{
    public class MansCategory
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public List<MansBrands> MansBrands { get; set; }
        public List<ManProduct> ManProducts { get; set; }
         public int GendersId { get; set; }
        public Genders Genders { get; set; }
        
        
           
    }
}