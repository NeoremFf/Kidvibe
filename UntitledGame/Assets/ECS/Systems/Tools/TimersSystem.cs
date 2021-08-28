using Entitas;
using UnityEngine;

namespace Kidvibe.Assets.ECS.Systems.Tools
{
  public class TimersSystem : IExecuteSystem
  {
    private readonly IGroup<GameEntity> CdGroup;

    public TimersSystem(GameContext context)
    {
      CdGroup = context.GetGroup(GameMatcher.Timers);
    }

    public void Execute()
    {
      foreach (var entity in CdGroup)
      {
        foreach (var timer in entity.timers.bodies)
        {
          if (timer.IsActive)
            timer.Tick(Time.deltaTime);
        }
      }
    }
  }
}
