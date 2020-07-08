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
        public static void AddToStore(SKU sku)
        {
            _itemsInStore.Add(sku);
        }

        public static SKU GetSKUIfInStore(char skuId)
        {
            SKU skuFound = null;

            if (_itemsInStore.Count > 0)
            {
                skuFound = _itemsInStore.FirstOrDefault(x => x.Id.Equals(char.ToUpperInvariant(skuId)));
            }

            return skuFound;
        }
    }
}
