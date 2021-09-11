using System;
using System.Collections.Generic;
using Kidvibe.ECS.Components.Game.Timer.Bodies;
using Zenject;

namespace Kidvibe.ECS.Components.Game.Timer.Pools
{
  public class PlayerTimerPool : ITimerPool
  {
    public IReadOnlyCollection<TimerBody> Bodies => Pool.Values;

    public Dictionary<Type, TimerBody> Pool { get; }

    [Inject]
    public PlayerTimerPool(DiContainer di)
    {
      Pool = new Dictionary<Type, TimerBody>()
      {
         [typeof(TimerBodyDashDuration)] = di.Instantiate<TimerBodyDashDuration>(),
      };
    }

    public TimerBody GetBy<TBodyType>() where TBodyType : TimerBody
    {
      var timer = Pool[typeof(TBodyType)];
      return timer;
    }
  }
}