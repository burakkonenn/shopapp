using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace app.entity
{
    public class Womans
    {
        public int Id { get; set; }
        public string Name { get; set; }
         public string Url { get; set; }
        public List<WomansCategory> WomansCategory { get; set; }
        public List<WomansBrands> WomansBrands { get; set; }
        public List<WomanProduct> WomanProducts { get; set; }
    }
}