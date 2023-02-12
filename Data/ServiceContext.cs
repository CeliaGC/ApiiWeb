using Entities.Entities;
using Entities.OrderRequest;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class ServiceContext : DbContext
    {
        public ServiceContext(DbContextOptions<ServiceContext> options) : base(options) { }
        public DbSet<ProductItem> Products { get; set; }
        public DbSet<UserItem> Users { get; set; }
        public DbSet<UserRol> RolType { get; set; }
        public DbSet<OrderItem> Orders { get; set; }
        //public DbSet<newOrderRequest> OrderRequests { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<ProductItem>(entity => {
                entity.ToTable("Products");
            });
            builder.Entity<UserItem>(entity => {
                entity.ToTable("Users");
                entity.HasOne<UserRol>().WithMany().HasForeignKey(u => u.IdRol);
            });
            builder.Entity<UserRol>(entity =>
            {
                entity.ToTable("RolType");
            });
            builder.Entity<OrderItem>(entity =>
            {
                entity.ToTable("Orders");
                entity.HasOne<UserRol>().WithMany().HasForeignKey(o => o.IdRol);
                entity.HasOne<ProductItem>().WithMany().HasForeignKey(o => o.IdProduct);
            });

        }
    }
    public class ServiceContextFactory : IDesignTimeDbContextFactory<ServiceContext>
    {
        public ServiceContext CreateDbContext(string[] args)
        {
            var builder = new ConfigurationBuilder()
                   .SetBasePath(Directory.GetCurrentDirectory())
                   .AddJsonFile("appsettings.json", false, true);
            var config = builder.Build();
            var connectionString = config.GetConnectionString("ServiceContext");
            var optionsBuilder = new DbContextOptionsBuilder<ServiceContext>();
            optionsBuilder.UseSqlServer(config.GetConnectionString("ServiceContext"));

            return new ServiceContext(optionsBuilder.Options);
        }
    }
}
