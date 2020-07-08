using System.Collections.Generic;

namespace PromotionEngineNS
{
    public class BuySKU1andSKU2ForFixedPrice : IPromotion
    {
        private char _firstSKUId;
        private char _secondSKUId;
        private int _fixedPrice;

        public BuySKU1andSKU2ForFixedPrice(char firstSKUId, char secondSKUId, int fixedPrice)
        {
            _firstSKUId = firstSKUId;
            _secondSKUId = secondSKUId;
            _fixedPrice = fixedPrice;
        }        

        public int GetSavingsOnDiscount(List<SKU> skus)
        {
            if (skus == null || skus.Count == 0)
                return 0;

            int savings = 0;
            int countOfFirstSKU = 0;                    // count of SKU1
            int countOfSecondSKU = 0;

            // Get the no. of SKU1 and SKU2.
            // say the imput is C,D,C,D,C
            foreach (SKU sku in skus)
            {
                if (char.ToUpperInvariant(sku.Id).Equals(char.ToUpperInvariant(_firstSKUId)))
                {
                    countOfFirstSKU++;
                }
                else if (char.ToUpperInvariant(sku.Id).Equals(char.ToUpperInvariant(_secondSKUId)))
                {
                    countOfSecondSKU++;
                }
            }
            
            int noOfDiscountedUnits = 0;
            if (countOfFirstSKU > 0 && countOfSecondSKU > 0)
            {
                if (countOfFirstSKU < countOfSecondSKU)   // get the greater of the two sku in terms of occurrance in the cart ( C = 3, D =2)
                {
                    noOfDiscountedUnits = countOfFirstSKU;
                }
                else
                {
                    noOfDiscountedUnits = countOfSecondSKU;     // = 2  { {CD} {CD} }
                }
                int originalPriceOfFirstSku = Inventory.GetPriceBySKUId(_firstSKUId);         // SKU1 price
                int originalPriceOfSecondSku = Inventory.GetPriceBySKUId(_secondSKUId);       // SKU2 price

                int originalPriceOfDiscountedSKU = originalPriceOfFirstSku + originalPriceOfSecondSku;          // = 20 + 15 = 35
                int discountPerUnit = originalPriceOfDiscountedSKU - _fixedPrice;                               // = 35 - 30 = 5
                savings = discountPerUnit * noOfDiscountedUnits;                                                // = 2 * 5 = 10
            }

            // 10 on C,D,C,D,C
            return savings;
        }

        
    }
}
