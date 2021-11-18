using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using app.entity;

namespace app.webui.Models
{
    public class CreateWomanBrandsModel
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Url { get; set; }
        [Required]
        public int WomansCategoryId { get; set; }
        [Required]
        public int GendersId { get; set; }
        public List<WomanProduct> WomanProducts { get; set; }
        
        
    }
}