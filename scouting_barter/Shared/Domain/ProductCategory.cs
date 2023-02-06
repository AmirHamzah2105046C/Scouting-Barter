using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace scouting_barter.Shared.Domain
{
    public class ProductCategory : BaseDomainModel
    {
        public string ProductCatType { get; set; }
        public string ProductCatDesc { get; set; }
        //public virtual List<Product> Products { get; set; }

    }
}
