using System;
using System.Collections.Generic;
using Kidvibe.Assets.ECS.Components.Game.Timer.Bodies;
using Kidvibe.Assets.ECS.Components.Game.Timer.Pools;
using Zenject;

namespace Kidvibe.Assets.ECS.Components.Game.Timer
{
  public abstract class TimerPool
  {
    private Dictionary<Type, TimerBody> _pool = new Dictionary<Type, TimerBody>();

    protected TimerPool(Dictionary<Type, TimerBody> pool) =>
      _pool = pool;

    public TimerBody GetBy<TBodyType>() =>
      _pool[typeof(TBodyType)];
  }

  public static class TimePoolsConfig
  {
    [Inject]
    public static PlayerTimerPool PlayerTimerPool(InjectContext context) =>
      new PlayerTimerPool(new Dictionary<Type, TimerBody>()
      {
        [typeof(TimerBodyDashDuration)] = context.Container.Instantiate<TimerBodyDashDuration>(),
      });
  }
}