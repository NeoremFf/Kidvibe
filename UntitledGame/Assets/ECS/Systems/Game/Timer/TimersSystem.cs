using Entitas;
using UnityEngine;

namespace Kidvibe.Assets.ECS.Systems.Game.Timer
{
  public class TimersSystem : IExecuteSystem, IInitializeSystem
  {
    private readonly IGroup<GameEntity> Timers;

    public TimersSystem(GameContext context)
    {
      Timers = context.GetGroup(GameMatcher.Timers);
    }

    public void Initialize()
    {
      foreach (var entity in Timers)
        entity.timers.Init();
    }

    public void Execute()
    {
      foreach (var entity in Timers.GetEntities())
      foreach (var timer in entity.timers.bodies)
        timer.Tick(Time.deltaTime);
    }
  }
}