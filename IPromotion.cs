using System;
using System.Collections.Generic;

namespace PromotionEngineNS
{
    // Base interface for all the promotions
    public interface IPromotion
    {
        // Each class that implements this interface determines how discount is calculated. 
        // Given the cart, it calculates the savings for that particular promotion on the whole cart.
        int GetSavingsOnDiscount(List<SKU> skus);
    }
}
