using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Domain
{
    public class Product
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string Picture { get; set; }
        public string Date { get; set; }
        public int Price { get; set; }
        public int Quantity { get; set; }

    }
}
