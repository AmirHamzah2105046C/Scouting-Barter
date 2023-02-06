using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace scouting_barter.Shared.Domain
{
    public class Product : BaseDomainModel
    {
        public string ProductName { get; set; }
        public string ProductDesc { get; set; }
        public int ProductPrice { get; set; }
        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }
        public int ProductCategoryId { get; set; }
        public virtual ProductCategory ProductCategory { get; set; }
    }
}
