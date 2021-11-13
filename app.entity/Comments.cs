using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace app.entity
{
    public class Comments
    {
        public int Id { get; set; }
        
        public string Name { get; set; }
        
        public string Post { get; set; }
        public string Email { get; set; }
        
        
        public System.DateTime Date { get; set; }
        
        public int ProductId { get; set; }
        public ManProduct Product { get; set; }
        public int Like { get; set; }
        
        
        

        
    }
}