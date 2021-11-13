using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using app.entity;

namespace app.webui.Models
{
    public class ProductEdit
    {
        public int ProductId { get; set; }
        
        
        [Required]
        public string Name { get; set; }

        [Required]
        public double Price { get; set; }

        [Required]
        public string Url { get; set; }

        [Required]
        public string Image { get; set; }
        public List<MansCategory> SelectedCategories { get; set; }
        
        
    }
}