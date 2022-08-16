using System;
using System.Collections.Generic;
using StoreCore.Model;

namespace StoreCore.Storages.ProductStorages
{
  /// <summary>
  /// Интерфейс доступа к данным о продуктах.
  /// </summary>
  public interface IProductStorage
  {
    /// <summary>
    /// Добавить продукт.
    /// </summary>
    /// <param name="productBasket">Продукт для добовления в корзину.</param>
    bool AddProduct(ProductBasket productBasket);

    /// <summary>
    /// Убрать продукт из корзины.
    /// </summary>
    /// <param name="productBasket">Продукт в корзине.</param>
    bool RemoveProduct(ProductBasket productBasket);

    /// <summary>
    /// Получить список продуктов.
    /// </summary>
    /// <param name="predicate">Предикат для фильтрации.</param>
    IEnumerable<ProductBasket> GetProducts(Func<ProductBasket, bool> predicate);

    /// <summary>
    /// Получить продукт по идентификатору
    /// </summary>
    /// <param name="idGuid">Идентификатор.</param>
    /// <returns>Продукт, если он найден, иначе null.</returns>
    ProductBasket FirstOrDefaultProduct(Guid idGuid);

  }
}
