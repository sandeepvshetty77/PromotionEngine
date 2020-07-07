using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PromotionEngineNS;

namespace UnitTestPromotionEngine
{
    [TestClass]
    public class UnitTestPromotionEngine
    {
        [TestMethod]
        public void TestNullCart()
        {
            PromotionEngine promotionEngine = new PromotionEngine();
            int finalTotal = promotionEngine.GetFinalTotal();
            Assert.AreEqual(0, finalTotal);
        }

        [TestMethod]
        public void TestEmptyCart()
        {
            PromotionEngine promotionEngine = new PromotionEngine("");
            int finalTotal = promotionEngine.GetFinalTotal();
            Assert.AreEqual(0, finalTotal);
        }
    }
}
