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
            return _finalTotal;
        }
    }
}
