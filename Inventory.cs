using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromotionEngineNS
{
    public static class Inventory
    {
        private static List<SKU> _itemsInStore = null;

        static Inventory()
        {
            _itemsInStore = new List<SKU>();
        }
    }
}
