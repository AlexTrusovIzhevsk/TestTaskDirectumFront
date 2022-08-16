using System;

namespace Store.Exceptions
{
  /// <summary>
  /// Ошибка, недостаточносто товара на складе.
  /// </summary>
  public class ProductNotEnoughInStockException : Exception
  {
    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="message">Сообщение.</param>
    /// <param name="innerException">Внутренее исключение.</param>
    public ProductNotEnoughInStockException(string message) : base(message) {  }
  }
}
