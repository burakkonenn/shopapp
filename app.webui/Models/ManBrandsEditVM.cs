using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using app.entity;

namespace app.webui.Models
{
    public class ManBrandsEditVM
    {
        public int Id { get; set; }
        
        [Required]
        public string Name { get; set; }
        [Required]
        public string Url { get; set; }
         [Required(ErrorMessage="Tür zorunludur.")] 
        public int MansCategoryId { get; set; }
         [Required(ErrorMessage="Tür zorunludur.")] 
        public string MansCategory { get; set; }
         [Required(ErrorMessage="Tür zorunludur.")]         
        public int GendersId { get; set; }
         [Required(ErrorMessage="Tür zorunludur.")] 
        public string Genders { get; set; }
        
          
        public List<ManProduct> ManProducts { get; set; }        
        
        
    }
}