using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orders.Domain
{
    public class Order
    {
        public int Id { get; set; }
        public string OrderNumber { get; set; }
        public DateTime OrderDate { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
        public virtual Decimal OrderTotal {get; set;}
    }
}
