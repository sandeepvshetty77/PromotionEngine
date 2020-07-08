using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromotionEngineNS
{
    public class SKU
    {
        public SKU(char id, int price)
        {
            Id = id;
            Price = price;
        }
        public char Id { get;  }
        public int Price { get; }
    }
}
