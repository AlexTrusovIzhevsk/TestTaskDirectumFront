using System;
using System.Collections.Generic;
using System.Linq;
using StoreCore.Model;

namespace StoreCore.Storages.ProductStorages
{
  /// <summary>
  /// Хранилище данных о продуктах на склдае магазина.
  /// </summary>
  public class StoreStorage : IProductStorage
  {
    #region Поля и свойства

    private IProductStorage instance = FileProductStorage.Instance;

    #endregion

    #region Методы

    /// <summary>
    /// Проверить продукт что он на складе.
    /// </summary>
    /// <param name="productBasket">Продукт.</param>
    private bool CheckProductBasket(ProductBasket productBasket)
    {
      return productBasket != null && productBasket.Owner == null;
    }

    #endregion

    #region IProductStorage

    public bool AddProduct(ProductBasket productBasket)
    {
      if (!this.CheckProductBasket(productBasket))
        throw new ArgumentException($"An error occurred while trying to add an item to the warehouse.");

      return this.instance.AddProduct(productBasket);
    }

    public bool RemoveProduct(ProductBasket productBasket)
    {
      if (!this.CheckProductBasket(productBasket))
        throw new ArgumentException($"An error occurred while trying to remove an item to the warehouse.");

      return this.instance.RemoveProduct(productBasket);
    }

    public IEnumerable<ProductBasket> GetProducts(Func<ProductBasket, bool> predicate)
    {
      return this.instance.GetProducts(predicate).Where(p => this.CheckProductBasket(p));
    }

    public ProductBasket FirstOrDefaultProduct(Guid idGuid)
    {
      return this.instance.GetProducts(p => this.CheckProductBasket(p) && p.Product.Id == idGuid).FirstOrDefault();
    }

    #endregion
  }
}
