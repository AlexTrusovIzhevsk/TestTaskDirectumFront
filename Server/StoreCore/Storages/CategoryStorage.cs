using System;
using System.Collections.Generic;
using StoreCore.Model;
using StoreCore.Storages.ProductStorages;

namespace Store.Storages
{
  public class CategoryStorage
  {

    private readonly IProductStorage storeStorage = new StoreStorage();

    /// <summary>
    /// Получение списка категорий.
    /// </summary>
    public string[] GetCategory()
    {
      return Enum.GetNames(typeof(Category));
    }

    /// <summary>
    /// Получение всех товаров магазниа данной категории.
    /// </summary>
    /// <param name="category">Категория.</param>
    public IEnumerable<ProductBasket> GetCategoryProducts(Category category)
    {
      return this.storeStorage.GetProducts(p => (Category)p.Product.Category == category);
    }
  }
}
