using PromotionEngineNS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromotionEngineNS
{
    public static class PromotionStore
    {
        // List of different promotions as objects
        static List<IPromotion> promotionList = new List<IPromotion>();

        public static void AddPromotion(IPromotion promotion)
        {
            promotionList.Add(promotion);
        }

        public static List<IPromotion> GetAllPromotions()
        {
            return promotionList;
        }
    }
}
