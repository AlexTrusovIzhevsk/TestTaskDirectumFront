using System;

namespace Store.Exceptions
{
  /// <summary>
  /// Ошибка, недостаточносто товара в корзине.
  /// </summary>
  public class ProductNotEnoughInBasketException : Exception
  {
    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="message">Сообщение.</param>
    /// <param name="innerException">Внутренее исключение.</param>
    public ProductNotEnoughInBasketException(string message) : base(message) {  }
  }
}
