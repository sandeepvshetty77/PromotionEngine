using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromotionEngineNS
{
    public class PromotionEngine
    {
        private string _cart;
        private int _finalTotal = 0;

        public PromotionEngine()
        {
            _cart = String.Empty;
            _finalTotal = 0;
        }

        public PromotionEngine(string cart)
        {
            _cart = cart.Trim();
            _finalTotal = 0;
        }

        public int GetFinalTotal()
        {
            if (_cart.Length == 0)
            {
                _finalTotal = 0;
            }
            else
            {
                SKU sku = getSKUsFromCart(_cart);
                _finalTotal = sku.Price;                
            }
            return _finalTotal;
        }

        private SKU getSKUsFromCart(string cart)
        {
            string skuId = String.Empty;
            SKU sku = null;
            skuId = cart.Trim().ToUpperInvariant();
            if (skuId.Length == 1)
            {
                sku = Inventory.GetSKUIfInStore(skuId[0]);
            }

            return sku;
        }
    }
}
