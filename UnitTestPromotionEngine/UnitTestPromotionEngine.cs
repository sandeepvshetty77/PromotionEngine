using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PromotionEngineNS;

namespace UnitTestPromotionEngine
{
    [TestClass]
    public class UnitTestPromotionEngine
    {

        [TestInitialize]
        public void Initialize()
        {
            SKU skuA = new SKU('A', 50);
            SKU skuB = new SKU('B', 30);
            SKU skuC = new SKU('C', 20);
            SKU skuD = new SKU('D', 15);

            Inventory.AddToStore(skuA);
            Inventory.AddToStore(skuB);
            Inventory.AddToStore(skuC);
            Inventory.AddToStore(skuD);
        }

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

        [TestMethod]
        [DataRow("A", 50)]
        [DataRow("B", 30)]
        [DataRow("C", 20)]
        [DataRow("D", 15)]
        public void TestOneValidItemInCart(string cart, int expectedTotal)
        {
            PromotionEngine promotionEngine = new PromotionEngine(cart);
            int finalTotal = promotionEngine.GetFinalTotal();
            Assert.AreEqual(expectedTotal, finalTotal);
        }
    }
}
