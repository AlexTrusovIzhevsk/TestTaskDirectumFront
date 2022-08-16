using System;

namespace Store.Exceptions
{
  /// <summary>
  /// Ошибка отсутствия товара в корзине.
  /// </summary>
  public class ProductNotInBasketException : Exception
  {
    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="message">Сообщение.</param>
    /// <param name="innerException">Внутренее исключение.</param>
    public ProductNotInBasketException(string message) : base(message) { }
  }
}
