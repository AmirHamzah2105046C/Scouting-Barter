using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace scouting_barter.Shared.Domain
{
    public class OrderItem : BaseDomainModel
    {
        public int ProductQuantity { get; set; }
        public int? ProductId { get; set; }
        public virtual Product Product { get; set; }
        public int? OrderId { get; set; }
        public virtual Order Order { get; set; }
        public virtual List<Order> Orders { get; set; }
    }
}
