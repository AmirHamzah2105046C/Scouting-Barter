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
            builder.HasData(
                new Customer
                {
                    Id = 1,
                    CustName = "Jonathan Lim",
                    CustAddress = "Tampines Street 1",
                    CustContact = 91890078,
                    CustDOB = "05/09/2001"
                },
                new Customer
                {
                    Id = 2,
                    CustName = "Haziq Hakim",
                    CustAddress = "Serangoon Street 1",
                    CustContact = 85788009,
                    CustDOB = "10/06/1985"
                },
                new Customer
                {
                    Id = 3,
                    CustName = "Gerald",
                    CustAddress = "Toa Payoh Street 1",
                    CustContact = 95437721,
                    CustDOB = "28/03/1999"
                }
            );
        }
    }
}
