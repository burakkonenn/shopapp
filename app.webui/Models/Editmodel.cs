using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using app.entity;

namespace app.webui.Models
{
    public class Editmodel
    {
        [Required(ErrorMessage ="Name zorunlu alan.")]
        public string Name { get; set; }
        public int ProductId { get; set; }
        
        [Required(ErrorMessage ="Price zorunlu alan.")]
        public double? Price { get; set; }

        [Required(ErrorMessage ="ImageUrl zorunlu alan.")]
        public string Image { get; set; }
        
        [Required(ErrorMessage ="Url zorunlu alan.")]
        public string Url { get; set; }
        public List<MansCategory> SelectedCategories { get; set; }
        
        
    }
}