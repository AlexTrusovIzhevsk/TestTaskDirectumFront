using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using Store.Exceptions;
using StoreCore.Model;

namespace StoreCore.Storages.ProductStorages
{
  /// <summary>
  /// Файловое хранилище данных о продуктах.
  /// </summary>
  internal class FileProductStorage : IProductStorage
  {
    #region Поля и свойства

    /// <summary>
    /// Синглтон.
    /// </summary>
    public static FileProductStorage Instance { get => lazy.Value; }
    private static readonly Lazy<FileProductStorage> lazy =
      new Lazy<FileProductStorage>(() => new FileProductStorage());

    private List<ProductBasket> products;
    private object lockProducts = new object();
    private readonly string storagePath = ConfigurationManager.AppSettings["StoragePath"];

    #endregion

    #region Методы

    /// <summary>
    /// Сохранение данных в файловом хранилище.
    /// </summary>
    private void Save()
    {
      var text = JsonConvert.SerializeObject(this.products.ToArray());
      File.WriteAllText(this.storagePath, text);
    }

    #endregion

    #region IProductStorage

    public bool AddProduct(ProductBasket productBasket)
    {
      lock (this.lockProducts)
      {
        this.products.Add(productBasket);
        this.Save();
        return true;
      }
    }

    public bool RemoveProduct(ProductBasket productBasket)
    {
      lock (this.lockProducts)
      {
        this.products.Remove(productBasket);
        this.Save();
        return true;
      }
    }

    public IEnumerable<ProductBasket> GetProducts(Func<ProductBasket, bool> predicate)
    {
      lock (this.lockProducts)
      {
        return this.products.Where(predicate).ToArray();
      }
    }

    public ProductBasket FirstOrDefaultProduct(Guid idGuid)
    {
      lock (this.lockProducts)
      {
        return this.products.FirstOrDefault(p => p.Product.Id == idGuid);
      }
    }

    #endregion

    #region Конструкторы

    /// <summary>
    /// Конструктор.
    /// </summary>
    private FileProductStorage()
    {
      try
      {
        var text = File.ReadAllText(this.storagePath);
        this.products = JsonConvert.DeserializeObject<List<ProductBasket>>(text);
      }
      catch (Exception exception)
      {
        throw new StorageUnavailableException($"Файловое хранилище недоступно, путь: {this.storagePath}", exception);
      }
    }

    #endregion
  }
}
