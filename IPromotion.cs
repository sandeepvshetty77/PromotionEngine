using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromotionEngineNS
{
    interface IPromotion
    {
        int GetSavingsOnDiscount(List<SKU> skus);
    }
}
