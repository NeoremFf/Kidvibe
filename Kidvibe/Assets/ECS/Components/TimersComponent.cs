using System.Collections.Generic;
using Entitas;
using Kidvibe.Assets.Utils.Exceptions;
using Kidvibe.Game.Timer;
using Kidvibe.Game.Timer.Pools;
using Kidvibe.GameLogic.Timer;

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

    public void Continue<TTimerType>()       
      where TTimerType : TimerBody, new() =>
      Get<TTimerType>().Continue();

    public void Pause<TTimerType>() 
      where TTimerType : TimerBody, new() =>
      Get<TTimerType>().Pause();

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