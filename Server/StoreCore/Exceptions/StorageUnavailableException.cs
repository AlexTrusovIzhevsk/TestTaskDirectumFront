using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Exceptions
{
  public class StorageUnavailableException : Exception
  {
    public StorageUnavailableException(string message, Exception innerException) : base(message, innerException) {  }
  }
}
