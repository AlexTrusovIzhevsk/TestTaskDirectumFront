using System;
using System.Collections.Generic;
using System.Linq;
using StoreCore.Model;

namespace StoreCore.Storages.ProductStorages
{
  public class StoreStorage : IProductStorage
  {
    private IProductStorage instance = FileProductStorage.Instance;

    public bool AddProduct(ProductBasket productBasket)
    {
      if (!CheckProductBasket(productBasket))
        throw new ArgumentException($"An error occurred while trying to add an item to the warehouse.");

      return instance.AddProduct(productBasket);
    }

    public bool RemoveProduct(ProductBasket productBasket)
    {
      if (!CheckProductBasket(productBasket))
        throw new ArgumentException($"An error occurred while trying to remove an item to the warehouse.");

      return instance.RemoveProduct(productBasket);
    }

    public IEnumerable<ProductBasket> GetProducts(Func<ProductBasket, bool> predicate)
    {
      return instance.GetProducts(predicate).Where(p => CheckProductBasket(p));
    }

    public ProductBasket FirstOrDefaultProduct(Guid idGuid)
    {
      return instance.GetProducts(p => CheckProductBasket(p) && p.Product.Id == idGuid).FirstOrDefault();
    }

    private bool CheckProductBasket(ProductBasket productBasket)
    {
      return productBasket != null && productBasket.Owner == null;
    }
  }
}
