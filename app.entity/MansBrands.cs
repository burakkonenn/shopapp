using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace app.entity
{
    public class MansBrands
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
      
        public int MansCategoryId { get; set; }
        public MansCategory MansCategory { get; set; }
        public List<ManProduct> ManProduct { get; set; }
         public int GendersId { get; set; }
        public Genders Genders { get; set; }
        

    }
}