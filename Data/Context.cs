using Core.Entity;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Data
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {
        }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Discount> Discounts { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<ProductFeatures> ProductFeatures { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            modelBuilder.Entity<Role>().HasData(
               new Role { Id = 1, CreateDate = DateTime.Now, Name = "SysAdmin", Status = true },
               new Role { Id = 2, CreateDate = DateTime.Now, Name = "Admin", Status = true },
               new Role { Id = 3, CreateDate = DateTime.Now, Name = "Customer", Status = true }
               );
            base.OnModelCreating(modelBuilder);
        }
        public override int SaveChanges()
        {
            foreach (var item in ChangeTracker.Entries())
            {
                if (item.Entity is BaseEntity baseEntity)
                {
                    switch (item.State)
                    {
                        case EntityState.Modified:
                            {
                                baseEntity.UpdateDate = DateTime.Now;
                                break;
                            }
                        case EntityState.Added:
                            {
                                baseEntity.Status = true;
                                baseEntity.CreateDate = DateTime.Now;
                                break;
                            }
                        default:
                            break;
                    }
                }
            }
            return base.SaveChanges();
        }
    }
}
