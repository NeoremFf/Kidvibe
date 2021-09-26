using System;
using System.Collections.Generic;
using Kidvibe.GameLogic.Timer.Bodies;
using Zenject;

namespace Kidvibe.GameLogic.Timer.Pools
{
  public class PlayerTimerPool : ITimerPool
  {
    public IReadOnlyCollection<TimerBody> Bodies => Pool.Values;

    private Dictionary<Type, TimerBody> Pool { get; }

    [Inject]
    public PlayerTimerPool(DiContainer di)
    {
      Pool = new Dictionary<Type, TimerBody>()
      {
        [typeof(TimerBodyDashDuration)]      = di.Instantiate<TimerBodyDashDuration>(),
        [typeof(TimerBodyDashChargeRefresh)] = di.Instantiate<TimerBodyDashChargeRefresh>(),
      };
    }

    public TimerBody GetBy<TBodyType>() where TBodyType : TimerBody =>
      Get<TBodyType>();

      private TimerBody Get<TBodyType>() where TBodyType : TimerBody
    {
      var body = Pool[typeof(TBodyType)];

      if (body == null)
        throw new ArgumentException($"Pool {nameof(PlayerTimerPool)} does not contained Body {nameof(TBodyType)}");
      
      return body;
    }
  }
}