using System.Collections.Generic;
using Entitas;
using Kidvibe.Assets.Utils.Exceptions;
using Kidvibe.ECS.Components.Game.Timer.Pools;

namespace Kidvibe.ECS.Components.Game.Timer
{
  public class TimersComponent : IComponent
  {
    public List<TimerBody> bodies;
    public ITimerPool pool;

    public GameEntity entity;

    public void Init()
    {
      bodies = new List<TimerBody>();
      foreach (var body in pool.Bodies)
        bodies.Add(body.Init(entity));
    }

    public void Continue<TTimerType>() where TTimerType : TimerBody =>
      Get<TTimerType>().Continue();

    public void Pause<TTimerType>() where TTimerType : TimerBody =>
      Get<TTimerType>().Pause();

    public void Set<TTimerType>() where TTimerType : TimerBody =>
      Get<TTimerType>().Run();

    public void Set<TTimerType>(float time) where TTimerType : TimerBody =>
      Get<TTimerType>().Run(time);

    private TimerBody Get<TTimerType>() where TTimerType : TimerBody
    {
      var body = pool.GetBy<TTimerType>();

      if (body == null)
        throw new TimerBodyMissingException(
          $"Timer body {typeof(TimerBodyMissingException)} is missing in {nameof(TimersComponent)}");

      return body;
    }
  }
}