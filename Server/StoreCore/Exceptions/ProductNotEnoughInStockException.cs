using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Exceptions
{
  /// <summary>
  /// Ошибка, недостаточносто товара на складе.
  /// </summary>
  public class ProductNotEnoughInStockException : Exception
  {
    public ProductNotEnoughInStockException(string message) : base(message)
    {
    }
  }
}
