using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace StoreCore.Common
{
  [JsonConverter(typeof(StringEnumConverter))]
  public enum Category
  {
    Computer,
    Laptop,
    Tablet,
    Phone,
    Accessory,
  }
}