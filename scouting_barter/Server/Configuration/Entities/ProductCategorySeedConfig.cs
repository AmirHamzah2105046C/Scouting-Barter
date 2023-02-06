using Microsoft.EntityFrameworkCore;
using scouting_barter.Shared.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace scouting_barter.Server.Configuration.Entities
{
    public class ProductCategorySeedConfig : IEntityTypeConfiguration<ProductCategory>
    {
        public void Configure(EntityTypeBuilder<ProductCategory> builder)
        {
            builder.HasData(
                new ProductCategory
                {
                    Id = 1,
                    DateUpdated = DateTime.Now,
                    DateCreated = DateTime.Now,
                    UpdatedBy = "Admin",
                    CreatedBy = "Admin",
                    ProductCatType = "Technological Devices",
                    ProductCatDesc = "Electronic devices that can be used for creating, storing, or transmitting information in the form of electronic data."
                },
                new ProductCategory
                {
                    Id = 2,
                    DateUpdated = DateTime.Now,
                    DateCreated = DateTime.Now,
                    UpdatedBy = "Admin",
                    CreatedBy = "Admin",
                    ProductCatType = "Furniture",
                    ProductCatDesc = "Household decorations"
                },
                new ProductCategory
                {
                    Id = 3,
                    DateUpdated = DateTime.Now,
                    DateCreated = DateTime.Now,
                    UpdatedBy = "Admin",
                    CreatedBy = "Admin",
                    ProductCatType = "Sports and Fitness",
                    ProductCatDesc = "Equipment that are used for exercises or sports"
                }
            );
        }
    }
}
