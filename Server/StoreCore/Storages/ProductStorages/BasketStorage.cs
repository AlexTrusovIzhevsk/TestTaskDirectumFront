using System;
using System.Collections.Generic;
using System.Linq;
using StoreCore.Model;

namespace StoreCore.Storages.ProductStorages
{
  /// <summary>
  /// Хранилище данных о продуктовой корзине.
  /// </summary>
  public class BasketStorage : IProductStorage
  {
    #region Поля и свойства

    private IProductStorage instance = FileProductStorage.Instance;
    private readonly string login;
    private readonly string password;

    #endregion

    #region Методы

    /// <summary>
    /// Создание дефолтного пользователя.
    /// </summary>
    public User CreateDefaultUser()
    {
      return new User() { Login = login, Password = password };
    }

    /// <summary>
    /// Проверить продукт что он в корзине.
    /// </summary>
    /// <param name="productBasket">Продукт.</param>
    private bool CheckProductBasket(ProductBasket productBasket)
    {
      return productBasket != null &&
             productBasket.Owner != null &&
             productBasket.Owner.Login == this.login &&
             productBasket.Owner.Password == this.password;
    }

    #endregion

    #region IProductStorage

    public bool AddProduct(ProductBasket productBasket)
    {
      if (!this.CheckProductBasket(productBasket))
        throw new ArgumentException($"An error occurred while trying to add an item to the cart.");

      return this.instance.AddProduct(productBasket);
    }

    public bool RemoveProduct(ProductBasket productBasket)
    {
      if (!this.CheckProductBasket(productBasket))
        throw new ArgumentException($"An error occurred while trying to remove an item to the cart.");

      return this.instance.RemoveProduct(productBasket);
    }

    public IEnumerable<ProductBasket> GetProducts(Func<ProductBasket, bool> predicate)
    {
      return this.instance.GetProducts(predicate)
        .Where(p => this.CheckProductBasket(p));
    }

    public ProductBasket FirstOrDefaultProduct(Guid idGuid)
    {
      return this.instance.GetProducts(p => this.CheckProductBasket(p) && p.Product.Id == idGuid).FirstOrDefault();
    }

    #endregion

    #region Конструкторы

    /// <summary>
    /// Конструктор.
    /// </summary>
    public BasketStorage()
    {
      this.login = "login";
      this.password = "12345";
    }

    #endregion
  }
}
