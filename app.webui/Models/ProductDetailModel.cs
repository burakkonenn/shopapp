using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using app.entity;

namespace app.webui.Models
{
    public class ProductDetailModel
    {
        public ManProduct Product { get; set; }
        
        
        public List<ManProduct> Category { get; set; }
        public List<ManProduct> Products { get; set; }        
        public List<Comments> Comments { get; set; }
        public string Name { get; set; }
        public string Post { get; set; }
        public int ProductId { get; set; }
        public System.DateTime Date { get; set; }
        public int totalCommentCount { get; set; }
        
        
        
        
        
        
                

    }
}