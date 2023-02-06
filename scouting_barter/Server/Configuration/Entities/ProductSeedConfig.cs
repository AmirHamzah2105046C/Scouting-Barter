using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using scouting_barter.Shared.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace scouting_barter.Server.Configuration.Entities
{
    public class ProductSeedConfig : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasData(
                new Product
                {
                    Id = 1,
                    DateUpdated = DateTime.Now,
                    DateCreated = DateTime.Now,
                    UpdatedBy = "Jonathan",
                    CreatedBy = "Jonathan",
                    ProductName = "Acer Laptop 1234",
                    ProductDesc = "MX150, Intel i3 1500, 8gb ram, 1tb hdd",
                    ProductPrice = 1100,
                    ProductCategoryId = 1,
                    CustomerId = 1,
                },
                new Product
                {
                    Id = 2,
                    DateUpdated = DateTime.Now,
                    DateCreated = DateTime.Now,
                    UpdatedBy = "Haziq",
                    CreatedBy = "Haziq",
                    ProductName = "Old Leather Couch",
                    ProductDesc = "1989 ld cow leather couch from syria",
                    ProductPrice = 500,
                    ProductCategoryId = 2,
                    CustomerId = 2
                },
                new Product
                {
                    Id = 3,
                    DateUpdated = DateTime.Now,
                    DateCreated = DateTime.Now,
                    UpdatedBy = "Gerald",
                    CreatedBy = "Gerald",
                    ProductName = "Fitness mat",
                    ProductDesc = "Sports fitness mat for yoga or other forms of aerobics",
                    ProductPrice = 35,
                    ProductCategoryId = 3,
                    CustomerId = 3
                }
            );
        }
    }
}
