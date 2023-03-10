using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace scouting_barter.Shared.Domain
{
    public class Customer : BaseDomainModel
    {
        public string CustName { get; set; }
        public string CustAddress { get; set; }
        public int CustContact { get; set; }
        //public virtual List<Product> Products { get; set; }
        public virtual List<Order> Orders { get; set; }
    }
}
