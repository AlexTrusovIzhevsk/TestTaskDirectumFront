using System;
using System.Collections.Generic;
using StoreCore.Model;

namespace StoreCore.Storages.ProductStorages
{
  public interface IProductStorage
  {
    bool AddProduct(ProductBasket productBasket);
    bool RemoveProduct(ProductBasket productBasket);
    IEnumerable<ProductBasket> GetProducts(Func<ProductBasket, bool> predicate);
    ProductBasket FirstOrDefaultProduct(Guid idGuid);
  }
}
