using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using StoreCore.Common;

namespace WebServer.Controllers
{
  public class StoreController : ApiController
  {
    [HttpGet]
    [ActionName("category")]
    public Array GetAllCategory()
    {
      return Store.GetCategory();
    }

    [HttpGet]
    [ActionName("category")]
    public Array GetCategory(Category parametr)
    {
      return Store.GetCategoryBasket(parametr);
    }

    [HttpGet]
    [ActionName("basket")]
    public Array GetBasket(string login = "login", string password = "12345")
    {
      return Store.GetUserBasket(login, password);
    }

    [HttpPut]
    [ActionName("productToBasket")]
    public HttpResponseMessage PutProductToUserBasket(string login, string password, Guid productId, int count)
    {
      try
      {
        Store.PutProductToUserBasket(login, password, productId, count);
        return new HttpResponseMessage(HttpStatusCode.OK);
      }
      catch (Exception e)
      {
        //ToDo Логирование
        return new HttpResponseMessage(HttpStatusCode.BadRequest);
      }

    }

    [HttpPut]
    [ActionName("productFromBasket")]
    public HttpResponseMessage TakeProductFromUserBasket(string login, string password, Guid productId, int count)
    {
      try
      {
        Store.TakeProductFromUserBasket(login, password, productId, count);
        return new HttpResponseMessage(HttpStatusCode.OK);
      }
      catch (Exception e)
      {
        //ToDo Логирование
        return new HttpResponseMessage(HttpStatusCode.BadRequest);
      }
    }
  }
}
