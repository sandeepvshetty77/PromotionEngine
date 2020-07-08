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

        [TestMethod]
        [DataRow("A, B", (50+30))]
        [DataRow("B, C", (30+20))]
        [DataRow("A, C", (50+20))]
        [DataRow("D, A", (15+50))]
        [DataRow("D, a", (15+50))]
        public void Test_Multiple_Valid_SKUs_In_Cart(string cart, int expectedTotal)
        {
            PromotionEngine promotionEngine = new PromotionEngine(cart);
            int finalTotal = promotionEngine.GetFinalTotal();
            Assert.AreEqual(expectedTotal, finalTotal);
        }

        [TestMethod]
        [DataRow("A, B, 1", (50 + 30))]
        [DataRow("B, C, g", (30 + 20))]
        [DataRow("A, C, H", (50 + 20))]
        [DataRow("D, A, PQR", (15 + 50))]
        [DataRow("D, a, 12", (15 + 50))]
        public void Test_Multiple_Valid_And_Invalid_SKUs_In_Cart(string cart, int expectedTotal)
        {
            PromotionEngine promotionEngine = new PromotionEngine(cart);
            int finalTotal = promotionEngine.GetFinalTotal();
            Assert.AreEqual(expectedTotal, finalTotal);
        }
    }
}
