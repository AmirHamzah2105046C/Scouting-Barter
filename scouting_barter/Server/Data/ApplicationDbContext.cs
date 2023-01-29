using IdentityServer4.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using scouting_barter.Server.Configuration.Entities;
using scouting_barter.Server.Configurations.Entities;
using scouting_barter.Server.Models;
using scouting_barter.Shared.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace scouting_barter.Server.Data
{
    public class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser>
    {
        public ApplicationDbContext(
            DbContextOptions options,
            IOptions<OperationalStoreOptions> operationalStoreOptions) : base(options, operationalStoreOptions)
        {
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new ProductCategorySeedConfig());
            builder.ApplyConfiguration(new ProductSeedConfig());
            builder.ApplyConfiguration(new RoleSeedConfiguration());
            builder.ApplyConfiguration(new UserRoleSeedConfiguration());
            builder.ApplyConfiguration(new UserSeedConfiguration());
            builder.ApplyConfiguration(new CustomerSeedConfig());
        }
    }
}
