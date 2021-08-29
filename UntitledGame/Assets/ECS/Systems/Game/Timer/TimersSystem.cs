using Entitas;
using UnityEngine;

namespace Kidvibe.Assets.ECS.Systems.Game.Timer
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
      foreach (var entity in CdGroup.GetEntities())
      foreach (var timer in entity.timers.bodies)
        timer.Tick(Time.deltaTime);
    }
  }
}