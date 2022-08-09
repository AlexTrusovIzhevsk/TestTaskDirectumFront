using System;
using System.Linq;
using System.Web.Http;
using Store.Storages;
using StoreCore.Model;
using StoreCore.Storages.ProductStorages;

namespace WebServer.Controllers
{
  public class CategoryController : ApiController
  {
    CategoryStorage categoryStorage = new CategoryStorage();

    [HttpGet]
    public Array GetAllCategory()
    {
      return CategoryStorage.GetCategory();
    }


    [HttpGet]
    [ActionName("list")]
    public Array GetCategoryProducts(Category parametr)
    {
      return categoryStorage.GetCategoryProducts(parametr).ToArray();
    }
  }
}
