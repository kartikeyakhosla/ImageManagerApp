using Microsoft.EntityFrameworkCore;

namespace ImageManagerApp.DB
{
    public class ImageManagerContext : DbContext
    {
        public ImageManagerContext(DbContextOptions<ImageManagerContext> options) : base(options)
        {
        }

        public DbSet<Customer> Customer { get; set; }
        public DbSet<Image> Image { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Image>(entity =>
            {
                
            });
            modelBuilder.Entity<Customer>(entity =>
            {

            });
        }
    }

    public class Image
    {
        public int ImageId { get; set; }
        public string ImageBase64 { get; set; } = string.Empty;
        public int CustomerId { get; set; }
    }

    public class Customer
    {
        public int CustomerId { get; set; }
        public string CustomerName { get; set; } = string.Empty;
    }
}
