using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apoteket.Domain.Orders
{
    public class Order
    {
        public int Id { get; set; }
        public string ItemName { get; set; }
        public int Quantity { get; set; }
    }
}
