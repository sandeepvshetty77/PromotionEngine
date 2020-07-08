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
            if (skus == null || skus.Count == 0)
                return 0;

            int savings = 0;
            int totalNumberOfDiscountedSKUsInCart = 0; // say 6 As  

            int originalPriceOfDiscountedSKU = Inventory.GetPriceBySKUId(_skuId);
            if (originalPriceOfDiscountedSKU == 0)
                return savings;

            foreach (SKU skuItem in skus)
            {
                if (skuItem.Id.Equals(_skuId))
                {
                    totalNumberOfDiscountedSKUsInCart++;                // say 6 As      
                }
            }

            // noOfDiscountedUnits = 6 / 3 = 2  = 2 sets of AAA
            int noOfDiscountedUnits = totalNumberOfDiscountedSKUsInCart / _numOfItems;

            if (noOfDiscountedUnits != 0)
            {
                // (3 * 150) - 130 = 20 per 3As
                int discountPerUnit = (originalPriceOfDiscountedSKU * _numOfItems) - _fixedPrice;

                // = 20 * 2 = 40
                savings = discountPerUnit * noOfDiscountedUnits;                
            }

            return savings;
        }
    }
}
