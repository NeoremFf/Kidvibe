using System.Collections.Generic;
using Entitas;

namespace Kidvibe.Assets.ECS.Components.Game.Timer
{
  public class TimersComponent : IComponent
  {
    public List<TimerBody> bodies;
    public TimerPool pool;

    public GameEntity entity;

    public void Init()
    {
      // bodies = 
    }

  public void Set<TTimerType>()
    {
      var set = pool.GetBy<TTimerType>();

      set.Run();
    }
      
    public void Set<TTimerType>(float time)
    {
      var set = pool.GetBy<TTimerType>();

      set.Run(time);
    }
  }
}