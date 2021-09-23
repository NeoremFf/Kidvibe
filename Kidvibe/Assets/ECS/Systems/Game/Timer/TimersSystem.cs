using Entitas;
using UnityEngine;

namespace Kidvibe.ECS.Systems.Game.Timer
{
  public class TimersSystem : IExecuteSystem, IInitializeSystem
  {
    private readonly IGroup<GameEntity> _timers;

    public TimersSystem(GameContext context)
    {
      _timers = context.GetGroup(GameMatcher.Timers);
    }

    public void Initialize()
    {
      foreach (var entity in _timers)
        entity.timers.Init();
    }

    public void Execute()
    {
      var deltaTime = Time.deltaTime;
      
      foreach (var entity in _timers)
      foreach (var timer in entity.timers.bodies)
        timer.Tick(deltaTime);
    }
  }
}