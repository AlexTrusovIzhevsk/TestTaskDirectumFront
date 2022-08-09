using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Exceptions
{
  /// <summary>
  /// Ошибка, недостаточносто товара в корзине.
  /// </summary>
  public class ProductNotEnoughInCartException : Exception
  {
    public ProductNotEnoughInCartException(string message) : base(message)
    {
    }
  }
}
