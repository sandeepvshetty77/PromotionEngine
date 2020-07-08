using PromotionEngineNS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            throw new NotImplementedException();
        }
    }
}
