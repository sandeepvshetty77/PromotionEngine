
namespace PromotionEngineNS
{
    // Basic Item class
    public class SKU
    {
        public SKU(char id, int price)
        {
            Id = id;
            Price = price;
        }
        public char Id { get;  }
        public int Price { get; }
    }
}
