namespace StoreCore.Model
{
  public class ProductBasket
  {
    public Product Product { get; set; }
    public User Owner { get; set; }
    public int Count { get; set; }

    public ProductBasket(Product product, User owner, int count)
    {
      Product = product;
      Owner = owner;
      Count = count;
    }
  }
}