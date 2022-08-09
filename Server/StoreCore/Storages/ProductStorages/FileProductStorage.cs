using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using Store.Exceptions;
using Store.Storages;
using StoreCore.Model;

namespace StoreCore.Storages.ProductStorages
{
  internal class FileProductStorage : IProductStorage
  {

    private static readonly Lazy<FileProductStorage> lazy =
      new Lazy<FileProductStorage>(() => new FileProductStorage());

    public static FileProductStorage Instance { get => lazy.Value; }


    private List<ProductBasket> products;
    private object lockProducts = new object();
    private readonly string storagePath = ConfigurationManager.AppSettings["StoragePath"];

    private FileProductStorage()
    {
      try
      {
        var text = File.ReadAllText(storagePath);
        products = JsonConvert.DeserializeObject<List<ProductBasket>>(text);
      }
      catch (Exception exception)
      {
        throw new StorageUnavailableException($"Файловое хранилище недоступно, путь: {storagePath}", exception);
      }
    }

    public bool AddProduct(ProductBasket productBasket)
    {
      lock (this.lockProducts)
      {
        this.products.Add(productBasket);
        Save();
        return true;
      }
    }

    public bool RemoveProduct(ProductBasket productBasket)
    {
      lock (this.lockProducts)
      {
        this.products.Remove(productBasket);
        Save();
        return true;
      }
    }

    public IEnumerable<ProductBasket> GetProducts(Func<ProductBasket, bool> predicate)
    {
      return this.products.Where(predicate);
    }

    public ProductBasket FirstOrDefaultProduct(Guid idGuid)
    {
      return products.FirstOrDefault(p => p.Product.Id == idGuid);
    }

    private void Save()
    {
      var text = JsonConvert.SerializeObject(this.products.ToArray());
      File.WriteAllText(this.storagePath, text);
    }
  }
}