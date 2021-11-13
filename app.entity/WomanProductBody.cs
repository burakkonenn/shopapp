using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace app.entity
{
    public class WomanProductBody
    {
        public int BodyId { get; set; }
        public Body Body { get; set; }
        public int WomanProductId { get; set; }
        public WomanProduct WomanProduct { get; set; }

    }
}