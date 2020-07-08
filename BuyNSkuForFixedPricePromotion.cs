using System.Collections.Generic;

namespace PromotionEngineNS
{
    public class BuyNSkuForFixedPricePromotion : IPromotion
    {
        private int _fixedPrice;
        private int _numOfItems;
        private char _skuId;

        public BuyNSkuForFixedPricePromotion(char skuId, int numOfItems, int fixedPrice)
        {
            _skuId = skuId;
            _numOfItems = numOfItems;
            _fixedPrice = fixedPrice;
        }

        public int GetSavingsOnDiscount(List<SKU> skus)
        {
            int savings = 0;
            int totalNumberOfDiscountedSKUsInCart = 0;

            int originalPriceOfDiscountedSKU = Inventory.GetPriceOfSKUBySKUId(_skuId);
            if (originalPriceOfDiscountedSKU == 0)
                return savings;

            foreach (SKU skuItem in skus)
            {
                if (skuItem.Id.Equals(_skuId))
                {
                    totalNumberOfDiscountedSKUsInCart++;                // say 6 As      
                }
            }

            // discountedUnit = 6 / 3 = 2
            int discountedUnit = totalNumberOfDiscountedSKUsInCart / _numOfItems;

            if (discountedUnit != 0)
            {
                // totalPrice  = 6 * 50 = 300
                int totalPrice = totalNumberOfDiscountedSKUsInCart * originalPriceOfDiscountedSKU;

                // priceAfterDiscount = 2 * 130 = 260
                int priceAfterDiscount = discountedUnit * _fixedPrice;

                // savings = 300 - 260 = 40
                savings = totalPrice - priceAfterDiscount;
            }

            return savings;
        }
    }
}
