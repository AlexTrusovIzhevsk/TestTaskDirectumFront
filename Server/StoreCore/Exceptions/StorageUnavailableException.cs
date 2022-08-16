using System;

namespace Store.Exceptions
{
  /// <summary>
  /// Ошибка доступа к файловому хранилищу.
  /// </summary>
  public class StorageUnavailableException : Exception
  {
    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="message">Сообщение.</param>
    /// <param name="innerException">Внутренее исключение.</param>
    public StorageUnavailableException(string message, Exception innerException) : base(message, innerException) {  }
  }
}
