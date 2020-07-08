using System.Collections.Generic;
using System.Linq;

namespace PromotionEngineNS
{
    // This is a placeholder for database which will hold all the SKUs in stock
    // There is no check made on the number of items  in stock. If the SKUId is valid then the stock info object is returned.
    public static class Inventory
    {
        private static List<SKU> _itemsInStore = null;

        static Inventory()
        {
            _itemsInStore = new List<SKU>();
        }

        public static void AddToStore(SKU sku)
        {
            if (sku != null)
                _itemsInStore.Add(sku);
        }

        public static SKU GetSKUFromStore(char skuId)
        {
            SKU skuFound = null;

            if (_itemsInStore.Count > 0)
            {
                skuFound = _itemsInStore.FirstOrDefault(sku => char.ToUpperInvariant(sku.Id).Equals(char.ToUpperInvariant(skuId)));
            }

            return skuFound;
        }

        public static int GetPriceBySKUId(char skuId)
        {
            SKU skuTemp = null;
            int skuPrice = 0;
            skuTemp = Inventory.GetSKUFromStore(skuId);
            if (skuTemp != null)
            {
                skuPrice = skuTemp.Price;
            }
            return skuPrice;
        }
    }
}
