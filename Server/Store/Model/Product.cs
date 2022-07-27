using System;
using StoreCore.Common;

namespace StoreCore.Model
{
  public class Product
  {
    public Guid Id { get; set; }

    public string Name { get; set; }
    
    public Category Category { get; set; }

    public decimal Price { get; set; }
  }
}