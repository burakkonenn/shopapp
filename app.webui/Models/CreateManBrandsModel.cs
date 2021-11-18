using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace app.webui.Models
{
    public class CreateManBrandsModel
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Url { get; set; }
        [Required]
        public int MansCategoryId { get; set; }
        [Required]
        public int GendersId { get; set; }
        
        
        
        
        
        
    }
}