using System.Collections.Generic;

namespace PromotionEngineNS
{
    // This class stores all the promotions
    public static class PromotionStore
    {
        // List of different promotions as objects
        static List<IPromotion> promotionList = new List<IPromotion>();

        // Adds the promotion to list
        public static void AddPromotion(IPromotion promotion)
        {
            if (promotion != null)
                promotionList.Add(promotion);
        }

        // Gets all the promotions available
        public static List<IPromotion> GetAllPromotions()
        {
            return promotionList;
        }
    }
}
