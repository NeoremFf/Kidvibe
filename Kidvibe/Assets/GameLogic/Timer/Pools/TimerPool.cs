using System;
using System.Collections.Generic;
using Kidvibe.GameLogic.Timer;

namespace Kidvibe.Game.Timer.Pools
{
  public interface ITimerPool
  {
    IReadOnlyCollection<TimerBody> Bodies { get; }

    Dictionary<Type, TimerBody> Pool { get; }

    TimerBody GetBy<TBodyType>() where TBodyType : TimerBody;
  }
}