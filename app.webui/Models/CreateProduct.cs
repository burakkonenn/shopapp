using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using app.entity;

namespace app.webui.Models
{
    public class CreateProduct
    {
        public int Id { get; set; }
        
        
        public List<MansCategory> SelectedCategory { get; set; }
        
        
        public int ProductId { get; set; }
        
        
        [Required]
        public string Name { get; set; }

        [Required]
        public double Price { get; set; }

        [Required]
        public string Url { get; set; }

        [Required]
        public string Image { get; set; }
        
        [Required]
        public string Description { get; set; }
        [Required]
        public int MansBrandsId { get; set; }
        [Required]
        public int MansCategoryId { get; set; }
        [Required]
        public int GendersId { get; set; }
        [Required]
        public int WomansBrandsId { get; set; }
        [Required]
        public int WomansCategoryId { get; set; }
  
        
        
        
        
        
    }
}