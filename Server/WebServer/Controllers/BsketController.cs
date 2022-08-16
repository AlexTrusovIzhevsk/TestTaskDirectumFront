using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Web.Http;
using Store.Exceptions;
using StoreCore.Model;
using StoreCore.Storages.ProductStorages;

namespace WebServer.Controllers
{
  /// <summary>
  /// Контроллер корзины.
  /// </summary>
  public class BasketController : ApiController
  {

    /// <summary>
    /// Хранилище данных о корзине.
    /// </summary>
    IProductStorage storeStorage = new StoreStorage();

    /// <summary>
    /// Получить список продуктов в корзине пользователя.
    /// </summary>
    [HttpGet]
    [ActionName("list")]
    public Array GetUserBasket()
    {
      var basketStorage = new BasketStorage();
      return basketStorage.GetProducts(p => true).ToArray();
    }

    /// <summary>
    /// Положить продукт в козрину пользователя.
    /// </summary>
    /// <param name="productId">Идентификатор продукта.</param>
    /// <param name="count">Количество продуктов.</param>
    [HttpPut]
    [ActionName("addProductToBasket")]
    public HttpResponseMessage PutProductToUserBasket(Guid productId, int count)
    {
      try
      {
        var basketStorage = new BasketStorage();

        var product = this.storeStorage.FirstOrDefaultProduct(productId);
        if (product is null)
          throw new ProductNotInStockException($"Product with id {productId} does not exist. ");
        if (product.Count < count)
          throw new ProductNotEnoughInStockException($"Product with id {productId} is not enough in stock. ");

        var productBasket = basketStorage.FirstOrDefaultProduct(productId);
        if (productBasket is null)
        {
          productBasket = new ProductBasket(product.Product, basketStorage.CreateDefaultUser(), count);
          basketStorage.AddProduct(productBasket);
        }
        else
        {
          productBasket.Count += count;
        }

        product.Count -= count;
        if (product.Count == 0)
          this.storeStorage.RemoveProduct(product);

        return new HttpResponseMessage(HttpStatusCode.OK);
      }
      catch (Exception exception)
      {
        return new HttpResponseMessage(HttpStatusCode.BadRequest)
        {
          Content = new ObjectContent(typeof(Exception), exception, new JsonMediaTypeFormatter())
        };
      }
    }

    /// <summary>
    /// Изъять продукт из козрины пользователя.
    /// </summary>
    /// <param name="productId">Идентификатор продукта.</param>
    /// <param name="count">Количество продуктов.</param>
    [HttpDelete]
    [ActionName("removeProductFromBasket")]
    public HttpResponseMessage TakeProductFromUserBasket(Guid productId, int count)
    {
      try
      {
        var basketStorage = new BasketStorage();
        
        var productBasket = basketStorage.FirstOrDefaultProduct(productId);
        if (productBasket is null)
          throw new ProductNotInBasketException($"Product with id {productId} does not exist in user basket.");
        if (productBasket.Count < count)
          throw new ProductNotEnoughInBasketException($"Product with id {productId} is not enough in user basket.");

        var storeBasket = this.storeStorage.FirstOrDefaultProduct(productId);
        if (storeBasket is null)
        {
          storeBasket = new ProductBasket(productBasket.Product, null, count);
          this.storeStorage.AddProduct(storeBasket);
        }
        else
        {
          storeBasket.Count += count;
        }

        productBasket.Count -= count;
        if (productBasket.Count == 0)
          basketStorage.RemoveProduct(productBasket);

        return new HttpResponseMessage(HttpStatusCode.OK);
      }
      catch (Exception exception)
      {
        return new HttpResponseMessage(HttpStatusCode.BadRequest)
        {
          Content = new ObjectContent(typeof(Exception), exception, new JsonMediaTypeFormatter())
        };
      }
    }
  }
}
