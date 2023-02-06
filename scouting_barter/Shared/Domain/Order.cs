using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace scouting_barter.Shared.Domain
{
    public class Order : BaseDomainModel
    {
        public DateTime OrderDate { get; set; }
        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }
        public int OrderItemId { get; set; }
        public virtual OrderItem OrderItem { get; set; }
        public virtual List<Payment> Payments { get; set; }
    }
}
