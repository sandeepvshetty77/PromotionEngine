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
                List<SKU> skuList = getSKUsFromCart(_cart);
                foreach (SKU sku in skuList)
                {
                    _finalTotal += sku.Price;
                }
                
            }
            return _finalTotal;
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
                    sku = Inventory.GetSKUIfInStore(skuId[0]);
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
