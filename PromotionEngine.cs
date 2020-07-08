using System;
using System.Collections.Generic;

namespace PromotionEngineNS
{
    public class PromotionEngine
    {
        private string _cart;

        public PromotionEngine()
        {
            _cart = String.Empty;
        }

        public PromotionEngine(string cart)
        {
            if (cart != null)
                _cart = cart.Trim();
        }

        public int GetFinalTotal()
        {
            int savings = 0;
            int finalTotal = 0;

            if (_cart.Length == 0)
            {
                finalTotal = 0;
            }
            else
            {
                List<SKU> skuList = getSKUsFromCart(_cart);

                savings = getSavingsForExistingPromotions(skuList);
                finalTotal = getTotalPriceOfCart(skuList);

                finalTotal = finalTotal - savings;
            }
            return finalTotal;
        }

        private int getTotalPriceOfCart(List<SKU> skuList)
        {
            int finalTotal = 0;
            // Calculate total price
            foreach (SKU sku in skuList)
            {
                finalTotal += sku.Price;
            }
            return finalTotal;
        }

        private int getSavingsForExistingPromotions(List<SKU> skuList)
        {
            int savings = 0;
            // Get all the active promotions
            List<IPromotion> promotiontList = PromotionStore.GetAllPromotions();

            // Send the cart to each promotion to get savings on each
            foreach (IPromotion promotion in promotiontList)
            {
                savings += promotion.GetSavingsOnDiscount(skuList);
            }

            return savings;
        }

        private List<SKU> getSKUsFromCart(string cart)
        {
            string skuId = String.Empty;
            List<SKU> skuList = null;
            SKU sku = null;

            string[] skuIds = cart.Split(',');
            for (int index = 0; index < skuIds.Length; index++)
            {
                skuId = skuIds[index].Trim().ToUpperInvariant();
                if (skuId.Length == 1)
                {
                    sku = Inventory.GetSKUFromStore(skuId[0]);
                    if (sku != null)
                    {
                        if (skuList == null)
                        {
                            skuList = new List<SKU>();
                        }
                        skuList.Add(sku);
                    }
                }
            }
            return skuList;
        }
    }
}
