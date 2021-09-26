using System.Collections.Generic;

namespace Kidvibe.GameLogic.Timer.Pools
{
  public interface ITimerPool
  {
    IReadOnlyCollection<TimerBody> Bodies { get; }
    
    TimerBody GetBy<TBodyType>() where TBodyType : TimerBody;
  }
}