using System.Collections.Generic;
using Entitas;
using Kidvibe.Assets.Utils.Exceptions;
using Kidvibe.GameLogic.Timer;
using Kidvibe.GameLogic.Timer.Pools;

namespace Kidvibe.ECS.Components
{
  public class TimersComponent : IComponent
  {
    public List<TimerBody> bodies;
    public ITimerPool pool;

    public GameEntity entity;

    #region Methods

    public void Init()
    {
      bodies = new List<TimerBody>();
      foreach (var body in pool.Bodies)
        bodies.Add(body.Init(entity));
    }

    public void Set<TTimerType>() 
      where TTimerType : TimerBody, new() =>
      Get<TTimerType>().Run();

    public void Delay<TTimerType>()
      where TTimerType : TimerBody, new() =>
      Get<TTimerType>().Delay();

    private TimerBody Get<TTimerType>() 
      where TTimerType : TimerBody, new()
    {
      var body = pool.GetBy<TTimerType>();

      if (body == null)
        throw new TimerBodyMissingException(
          $"Timer body {typeof(TimerBodyMissingException)} is missing in {nameof(TimersComponent)}");

      return body;
    }

    #endregion
  }
}