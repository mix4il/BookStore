using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Domain
{
    public class Orders
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string TotalPrice { get; set; }
        public int TotalQuantity { get; set; }

        public Product[] Books { get; set; }
    }
}
