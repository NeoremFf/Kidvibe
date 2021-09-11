using System;

namespace Kidvibe.Assets.Utils.Exceptions
{
  public class TimerBodyMissingException : Exception
  {
    public TimerBodyMissingException(string message) : base(message)
    {
    }
  }
}
