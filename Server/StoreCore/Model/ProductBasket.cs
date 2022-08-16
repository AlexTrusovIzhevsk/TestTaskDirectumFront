namespace StoreCore.Model
{
  /// <summary>
  /// Продукт в корзине.
  /// </summary>
  public class ProductBasket
  {
    #region Поля и свойства

    /// <summary>
    /// Продукт.
    /// </summary>
    public Product Product { get; set; }

    /// <summary>
    /// Владелец.
    /// </summary>
    public User Owner { get; set; }

    /// <summary>
    /// Количество.
    /// </summary>
    public int Count { get; set; }

    #endregion

    #region Конструкторы

    /// <summary>
    /// Конструтор.
    /// </summary>
    /// <param name="product">Продукт</param>
    /// <param name="owner">Владелец</param>
    /// <param name="count">Количество</param>
    public ProductBasket(Product product, User owner, int count)
    {
      this.Product = product;
      this.Owner = owner;
      this.Count = count;
    }

    #endregion
  }
}
