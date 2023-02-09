using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using scouting_barter.Shared.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace scouting_barter.Server.Configuration.Entities
{
    public class CustomerSeedConfig : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            _ = builder.HasData(
                new Customer
                {
                    Id = 1,
                    DateUpdated = DateTime.Now,
                    DateCreated = DateTime.Now,
                    UpdatedBy = "Jonathan",
                    CreatedBy = "Jonathan",
                    CustName = "Jonathan Lim",
                    CustAddress = "Tampines Street 1",
                    CustContact = 91890078

                },
                new Customer
                {
                    Id = 2,
                    DateUpdated = DateTime.Now,
                    DateCreated = DateTime.Now,
                    UpdatedBy = "Haziq",
                    CreatedBy = "Haziq",
                    CustName = "Haziq Hakim",
                    CustAddress = "Serangoon Street 1",
                    CustContact = 85788009
                },
                new Customer
                {
                    Id = 3,
                    DateUpdated = DateTime.Now,
                    DateCreated = DateTime.Now,
                    UpdatedBy = "Gerald",
                    CreatedBy = "Gerald",
                    CustName = "Gerald",
                    CustAddress = "Toa Payoh Street 1",
                    CustContact = 95437721
                }
            );
        }
    }
}
