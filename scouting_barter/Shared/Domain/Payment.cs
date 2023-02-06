using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace scouting_barter.Shared.Domain
{
    public class Payment :BaseDomainModel
    {
        public int TotalPrice { get; set; }
        public string PaymentType { get; set; }
        public DateTime PaymentDate { get; set; }
        public int OrderId { get; set; }
        public virtual Order Order { get; set; }
    }
}
