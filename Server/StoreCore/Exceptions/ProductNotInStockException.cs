using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Exceptions
{
  /// <summary>
  /// Ошибка отсутствия товара на складе.
  /// </summary>
  public class ProductNotInStockException : Exception
  {
    public ProductNotInStockException(string message) : base(message)
    {
    }
  }
}
