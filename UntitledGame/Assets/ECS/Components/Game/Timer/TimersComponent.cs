using System.Collections.Generic;
using Entitas;
using Kidvibe.Assets.ECS.Components.Game.Timer.Pools;

namespace Kidvibe.Assets.ECS.Components.Game.Timer
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

    public void Set<TTimerType>() where TTimerType : TimerBody
    {
      var set = pool.GetBy<TTimerType>();

      set.Run();
    }

    public void Set<TTimerType>(float time) where TTimerType : TimerBody
    {
      var set = pool.GetBy<TTimerType>();

      set.Run(time);
    }
  }
}