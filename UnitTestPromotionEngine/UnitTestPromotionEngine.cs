using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PromotionEngineNS;

namespace UnitTestPromotionEngine
{
    [TestClass]
    public class UnitTestPromotionEngine
    {
        // Add all the promotions available to the store upfront
        [ClassInitialize]
        public static void Init(TestContext testContext)
        {
            PromotionStore.AddPromotion(new BuyNSkuForFixedPricePromotion('A', 3, 130));
            PromotionStore.AddPromotion(new BuyNSkuForFixedPricePromotion('B', 2, 45));
        }

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
        public void Test_Null_Cart()
        {
            PromotionEngine promotionEngine = new PromotionEngine();
            int finalTotal = promotionEngine.GetFinalTotal();
            Assert.AreEqual(0, finalTotal);
        }

        [TestMethod]
        public void Test_Empty_Cart()
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
        public void Test_One_Valid_Item_In_Cart(string cart, int expectedTotal)
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

        [TestMethod]
        [DataRow("A, A, A", 130)]
        [DataRow("A, A, A, A, A, A", (130 + 130))]
        public void Test_Buy_n_Items_of_SKU_A_ForFixed_Price(string cart, int expectedTotal)
        {
            PromotionEngine promotionEngine = new PromotionEngine(cart);
            int finalTotal = promotionEngine.GetFinalTotal();
            Assert.AreEqual(expectedTotal, finalTotal);
        }

        [TestMethod]
        [DataRow("B, B", 45)]
        [DataRow("B, B, B, B", (45 + 45))]
        public void Test_Buy_n_Items_of_SKU_B_ForFixed_Price(string cart, int expectedTotal)
        {
            PromotionEngine promotionEngine = new PromotionEngine(cart);
            int finalTotal = promotionEngine.GetFinalTotal();
            Assert.AreEqual(expectedTotal, finalTotal);
        }
    }
}
