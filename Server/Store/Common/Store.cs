using System;
using System.Linq;
using StoreCore.Model;

namespace StoreCore.Common
{
  public class Store
  {
    public static string[] GetCategory()
    {
      return Enum.GetNames(typeof(Category));
    }

    public static Array GetUserBasket(string login, string password)
    {
      var basket = Storage.WhereProduct(p => p.Owner != null && p.Owner.Login == login && p.Owner.Password == password).ToArray();
      return basket;
    }

    public static Array GetCategoryBasket(Category category)
    {
      return Storage.WhereProduct(p => p.Owner == null && (Category)p.Product.Category == category).ToArray();
    }

    //ToDo убрать дублирование, выенсти методы.
    public static void PutProductToUserBasket(string login, string password, Guid productId, int count)
    {
      var productBasket = Storage.FirstOrDefaultProduct(p => p.Owner == null && p.Product.Id == productId);
      if (productBasket is null)
        throw new ArgumentException($"Product with id {productId} does not exist. ");
      if (productBasket.Count < count)
        throw new ArgumentException($"Product with id {productId} is not enough in stock. ");

      var userProduct = Storage.FirstOrDefaultProduct(p => p.Owner != null && p.Owner.Login == login && p.Owner.Password == password && p.Product.Id == productId);
      if (userProduct is null)
      {
        userProduct = new ProductBasket(productBasket.Product, new User(){ Login = login, Password = password}, count);
        Storage.AddProduct(userProduct);
      }
      else
      {
        userProduct.Count += count;
      }

      productBasket.Count -= count;
      if (productBasket.Count == 0)
        Storage.RemoveProduct(productBasket);
    }

    public static void TakeProductFromUserBasket(string login, string password, Guid productId, int count)
    {
      var productUserBasket = Storage.FirstOrDefaultProduct(p => p.Owner != null && p.Owner.Login == login && p.Owner.Password == password && p.Product.Id == productId);
      if (productUserBasket is null)
        throw new ArgumentException($"Product with id {productId} does not exist in user basket with login {login}. ");
      if (productUserBasket.Count < count)
        throw new ArgumentException($"Product with id {productId} is not enough in user basket with login {login}. ");

      var storeBasket = Storage.FirstOrDefaultProduct(p => p.Owner is null && p.Product.Id == productId);
      if (storeBasket is null)
      {
        storeBasket = new ProductBasket(productUserBasket.Product, null, count);
        Storage.AddProduct(storeBasket);
      }
      else
      {
        storeBasket.Count += count;
      }

      productUserBasket.Count -= count;
      if(productUserBasket.Count == 0)
        Storage.RemoveProduct(productUserBasket);
    }
  }
}