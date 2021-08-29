using System;

namespace Kidvibe.Assets.Utils.Exceptions
{
  public class EcsComponentMissingException : Exception
  {
    public EcsComponentMissingException(string message)
      : base(message)
    {
    }
  }
}
