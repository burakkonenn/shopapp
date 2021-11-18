using app.entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace app.data.Concrete.EfCore
{
    public class ShopContext:DbContext
    {
        public DbSet<Genders> Genders { get; set; }
        public DbSet<ManProduct> ManProducts { get; set; }
        public DbSet<MansCategory> MansCategories { get; set; }
        public DbSet<MansBrands> MansBrands { get; set; }
        public DbSet<ManProductBody> ManProductBodies { get; set; }
        
        
        public DbSet<WomanProduct> WomanProducts { get; set; }
        public DbSet<WomansCategory> WomansCategories { get; set; }
        public DbSet<WomansBrands> WomansBrands { get; set; }
        public DbSet<WomanProductBody> WomanProductBodies { get; set; }

        public DbSet<Body> Body { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        
        public DbSet<Comments> Comment { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source= appDb");
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ManProductBody>()
                .HasKey(c => new { c.ManProductId, c.BodyId }); 
            modelBuilder.Entity<WomanProductBody>()
                .HasKey(c => new { c.WomanProductId, c.BodyId });     
            
          
         }
        
        
    }
}