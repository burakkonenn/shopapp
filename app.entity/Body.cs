using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace app.entity
{
    public class Body
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public List<ManProductBody> ManProductBodies { get; set; }
        public List<WomanProductBody> WomanProductBodies { get; set; }
        
        
    }
}