using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Domain
{
    public class OrderDetail
    {
        public virtual int Id { get; set; }
        public virtual int OrderId { get; set; }
        public virtual string ItemName { get; set; }
        public virtual decimal ItemPrice { get; set; }
        public virtual int Quantity { get; set; }
    }
}
