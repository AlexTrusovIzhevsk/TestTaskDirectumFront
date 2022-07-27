using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using StoreCore.Model;

namespace StoreCore.Common
{
  public class Storage
  {
    private static List<ProductBasket> products;
    private static List<User> users;
    private static string fileName = @"D:\Projects\WebTemplate\Server\WebServer\bin\data.json";

    static Storage()
    {
      var text = File.ReadAllText(fileName);
      products = JsonConvert.DeserializeObject<List<ProductBasket>>(text);

      users = products
        .Select(p => p.Owner)
        .Where(u => u != null)
        .ToList();
    }

    public static void AddProduct(ProductBasket productBasket)
    {
      products.Add(productBasket);
      Save();
    }

    public static void RemoveProduct(ProductBasket productBasket)
    {
      products.Remove(productBasket);
      Save();
    }

    public static IEnumerable<ProductBasket> WhereProduct(Func<ProductBasket, bool> predicate)
    {
      return products.Where(predicate);
    }

    public static ProductBasket FirstOrDefaultProduct(Func<ProductBasket, bool> predicate)
    {
      return products.FirstOrDefault(predicate);
    }

    public static User GetUser(string login, string password)
    {
      return users.FirstOrDefault(u => u.Login == login && u.Password == password);
    }

    private static void Save()
    {
      var text = JsonConvert.SerializeObject(products.ToArray());
      File.WriteAllText(fileName, text);
    }
  }
}