using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace app.entity
{
    public class WomansBrands
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public int WomansCategoryId { get; set; }
        public WomansCategory WomansCategory { get; set; }
        public List<WomanProduct> WomanProducts { get; set; }
        public int GendersId { get; set; }
        public Genders Genders { get; set; }
    }
}