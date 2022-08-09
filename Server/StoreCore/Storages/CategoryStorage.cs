using System;
using System.Collections.Generic;
using System.Linq;
using StoreCore.Model;
using StoreCore.Storages.ProductStorages;

namespace Store.Storages
{
  public class CategoryStorage
  {
    IProductStorage storeStorage = new StoreStorage();

    public static string[] GetCategory()
    {
      return Enum.GetNames(typeof(Category));
    }

    public IEnumerable<ProductBasket> GetCategoryProducts(Category category)
    {
      return storeStorage.GetProducts(p => (Category)p.Product.Category == category);
    }
  }
}
