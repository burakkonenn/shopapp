using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace app.entity
{
    public class Persons
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        
        
        public List<MansCategory> ManCategory { get; set; }
        public List<MansBrands> MansBrands { get; set; }
        public List<ManProduct> ManProducts { get; set; }
        
        public List<WomanProduct> WomanProducts { get; set; }
        public List<WomansBrands> WomansBrands { get; set; }
        public List<WomansCategory> WomansCategories { get; set; }
        
        
    }
}