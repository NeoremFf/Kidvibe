using System;

namespace Kidvibe.Utils.Exceptions
{
  public class EcsComponentMissingException : Exception
  {
    public EcsComponentMissingException(string message)
      : base(message)
    {
    }
  }
}
