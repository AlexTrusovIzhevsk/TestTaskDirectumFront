using System;
using System.Linq;
using System.Web.Http;
using Store.Storages;
using StoreCore.Model;

namespace WebServer.Controllers
{
  /// <summary>
  /// Контроллер категорий.
  /// </summary>
  public class CategoryController : ApiController
  {

    /// <summary>
    /// Хранилище данных о категориях.
    /// </summary>
    CategoryStorage categoryStorage = new CategoryStorage();

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public Array GetAllCategory()
    {
      return this.categoryStorage.GetCategory();
    }

    [HttpGet]
    [ActionName("list")]
    public Array GetCategoryProducts(Category parametr)
    {
      return this.categoryStorage.GetCategoryProducts(parametr).ToArray();
    }
  }
}
