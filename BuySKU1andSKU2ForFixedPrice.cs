using PromotionEngineNS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromotionEngineNS
{
    public class BuySKU1andSKU2ForFixedPrice : IPromotion
    {
        char _firstSKU;
        char _secondSKU;
        int _fixedPrice;

        public BuySKU1andSKU2ForFixedPrice(char firstSKU, char secondSKU, int fixedPrice)
        {
            _firstSKU = firstSKU;
            _secondSKU = secondSKU;
            _fixedPrice = fixedPrice;
        }        

        public int GetSavingsOnDiscount(List<SKU> skus)
        {
            int savings = 0;
            int countOfFirstSKU = 0;
            int totalPriceForFirstAndSecondSkus = 0;
            int countOfSecondSKU = 0;
            int originalPriceOfFirstSku = Inventory.GetPriceOfSKUBySKUId(_firstSKU);
            int originalPriceOfSecondSku = Inventory.GetPriceOfSKUBySKUId(_secondSKU);

            foreach (SKU sku in skus)
            {
                if (char.ToUpperInvariant(sku.Id).Equals(char.ToUpperInvariant(_firstSKU)))
                {
                    countOfFirstSKU++;
                    totalPriceForFirstAndSecondSkus += sku.Price;
                }
                else if (char.ToUpperInvariant(sku.Id) == char.ToUpperInvariant(_secondSKU))
                {
                    countOfSecondSKU++;
                    totalPriceForFirstAndSecondSkus += sku.Price;
                }

            }

            int discountedUnits = 0;
            int discountedPrice = 0;
            int undiscountedPrice = 0;
            if (countOfFirstSKU < countOfSecondSKU)
            {
                discountedUnits = countOfFirstSKU;
                undiscountedPrice = (countOfSecondSKU - countOfFirstSKU) * originalPriceOfSecondSku;
            }
            else
            {
                discountedUnits = countOfSecondSKU;
                undiscountedPrice = (countOfFirstSKU - countOfSecondSKU) * originalPriceOfFirstSku;
            }
            discountedPrice = discountedUnits * _fixedPrice;

            savings = totalPriceForFirstAndSecondSkus - (discountedPrice + undiscountedPrice);

            return savings;
        }
    }
}
