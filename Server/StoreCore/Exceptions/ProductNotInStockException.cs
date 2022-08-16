using System;

namespace Store.Exceptions
{
  /// <summary>
  /// Ошибка отсутствия товара на складе.
  /// </summary>
  public class ProductNotInStockException : Exception
  {
    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="message">Сообщение.</param>
    /// <param name="innerException">Внутренее исключение.</param>
    public ProductNotInStockException(string message) : base(message) {  }
  }
}
