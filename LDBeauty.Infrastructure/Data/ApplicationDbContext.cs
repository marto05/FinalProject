using LDBeauty.Infrastructure.Data.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LDBeauty.Infrastructure.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<ApplicationUser>()
                .HasIndex(u => u.Email)
                .IsUnique();

            builder.Entity<UserImage>()
                .HasKey(x => new { x.ImageId, x.ApplicationUserId });

            builder.Entity<UserProduct>()
                .HasKey(x => new { x.ProductId, x.ApplicationUserId });

            // Seed Makes
            builder.Entity<Make>().HasData(
                new Make { Id = 1, MakeName = "Nars" },
                new Make { Id = 2, MakeName = "Cetaphil" },
                new Make { Id = 3, MakeName = "Ahmed" }
            );

            // Seed Categories
            builder.Entity<Category>().HasData(
                new Category { Id = 1, CategoryName = "Makeup" },
                new Category { Id = 2, CategoryName = "Skincare" },
                new Category { Id = 3, CategoryName = "Fragrance" }
            );

            builder.Entity<ImgCategory>().HasData(
                new ImgCategory { Id = 1, CategoryName = "Makeup-img", ImgUrl = "https://media-cldnry.s-nbcnews.com/image/upload/t_fit-1000w,f_auto,q_auto:best/rockcms/2024-06/240610-beauty-awards-2024-face-makeup-winners-vl-main-58813e.jpg" },
                new ImgCategory { Id = 2, CategoryName = "Skincare-img", ImgUrl = "https://media-cldnry.s-nbcnews.com/image/upload/t_fit-1000w,f_auto,q_auto:best/rockcms/2024-06/240610-beauty-awards-2024-skincare-winners-vl-main-b0c976.jpg" },
                new ImgCategory { Id = 3, CategoryName = "Fragrance-img", ImgUrl = "https://ambadar.com/storage/2023/12/can-parfume-fragrance-be-protected-by-copyrights-law-in-indonesia-20230707214332.jpg" }
            );

            builder.Entity<Image>().HasData(
                new Image { Id = 1, Description = "Makeup", ImageUrl = "https://media-cldnry.s-nbcnews.com/image/upload/t_fit-1000w,f_auto,q_auto:best/rockcms/2024-06/240610-beauty-awards-2024-face-makeup-winners-vl-main-58813e.jpg", CategoruId = 1 },
                 new Image { Id = 2, Description = "Skincare", ImageUrl = "https://media-cldnry.s-nbcnews.com/image/upload/t_fit-1000w,f_auto,q_auto:best/rockcms/2024-06/240610-beauty-awards-2024-skincare-winners-vl-main-b0c976.jpg", CategoruId = 2 },
                  new Image { Id = 3, Description = "Fragrance", ImageUrl = "https://ambadar.com/storage/2023/12/can-parfume-fragrance-be-protected-by-copyrights-law-in-indonesia-20230707214332.jpg", CategoruId = 3 }
            );

            // Seed UserImage (user's images)
            builder.Entity<UserImage>().HasData(
                new UserImage { ImageId = 1, ApplicationUserId = "71247a6c-ca6b-4cc8-9d5c-25b701e0f543" },
                new UserImage { ImageId = 2, ApplicationUserId = "71247a6c-ca6b-4cc8-9d5c-25b701e0f543" },
                new UserImage { ImageId = 3, ApplicationUserId = "71247a6c-ca6b-4cc8-9d5c-25b701e0f543" }
            );

            builder.Entity<Cart>().HasData(
                new Cart { Id = 1, TotalPrice = 42m, IsDeleted = false, UserId = "71247a6c-ca6b-4cc8-9d5c-25b701e0f543" }
            );

            // Seed Orders
            builder.Entity<Order>().HasData(
                new Order
                {
                    Id = 1,
                    ClientFirstName = "John",
                    ClientLastName = "Doe",
                    Address = "123 Main St",
                    Phone = "1234567890",
                    Email = "john.doe@example.com",
                    OrderDate = DateTime.Now,
                    TotalPrice = 79.98m,
                    ApplicationUserId = "71247a6c-ca6b-4cc8-9d5c-25b701e0f543"
                }
            );

            // Seed Products
            builder.Entity<Product>().HasData(
                new Product { Id = 1, ProductName = "Foundation", ProductUrl = "https://www.sephora.com/productimages/sku/s2514586-main-zoom.jpg?imwidth=315", Description = "Long-lasting foundation", Price = 29.99m, Quantity = 100, CategoryId = 1, MakeId = 1 },
                new Product { Id = 2, ProductName = "Moisturizer", ProductUrl = "https://cloudinary.images-iherb.com/image/upload/f_auto,q_auto:eco/images/cet/cet92804/l/24.jpg", Description = "Hydrating moisturizer", Price = 19.99m, Quantity = 200, CategoryId = 2, MakeId = 2 },
                new Product { Id = 3, ProductName = "Perfume", ProductUrl = "https://www.sbdiscounter.bg/wp-content/uploads/2021/04/new-oud-lavender-box-and-bottle-2.png", Description = "Elegant fragrance", Price = 49.99m, Quantity = 150, CategoryId = 3, MakeId = 3 }
            );

            // Seed AddedProducts (order items)
            builder.Entity<AddedProduct>().HasData(
                new AddedProduct { Id = 1, ProductId = 1, Quantity = 2, CartId = 1, OrderId = 1 },
                new AddedProduct { Id = 2, ProductId = 2, Quantity = 1, CartId = 1, OrderId = 1 }
            );

            // Seed UserProduct (user's products)
            builder.Entity<UserProduct>().HasData(
                new UserProduct { ApplicationUserId = "71247a6c-ca6b-4cc8-9d5c-25b701e0f543", ProductId = 1 },
                new UserProduct { ApplicationUserId = "71247a6c-ca6b-4cc8-9d5c-25b701e0f543", ProductId = 2 }
            );

        }

        public DbSet<AddedProduct> AddedProducts { get; set; }

        public DbSet<Cart> Carts { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Image> Images { get; set; }

        public DbSet<ImgCategory> ImgCategories { get; set; }

        public DbSet<Make> Makes { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<UserImage> UsersImages { get; set; }

        public DbSet<UserProduct> UsersProducts { get; set; }
    }
}