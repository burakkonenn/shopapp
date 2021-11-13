using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace app.entity
{
    public class ManProductBody
    {
        public int ManProductId { get; set; }
        public ManProduct ManProduct { get; set; }
        public int BodyId { get; set; }
        public Body Body { get; set; }
        
        
        
        
        
    }
}