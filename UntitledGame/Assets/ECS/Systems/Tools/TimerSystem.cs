using Kidvibe.Assets.ECS.Components.Tools;
using Leopotam.Ecs;
using UnityEngine;
using Zenject;

namespace Kidvibe.Assets.ECS.Systems.Tools
{
  public class TimerSystem : IEcsRunSystem
  {
    private EcsFilter<TimerComponent> _timerFilters;

    public void Run()
    {
      if (_timerFilters.IsEmpty())
        return;

      var time = Time.deltaTime;

      Execute(time);
    }

    private void Execute(float time)
    {
      foreach (var index in _timerFilters)
      {
        ref var timer = ref _timerFilters.Get1(index);

          timer.timeLeft -= time;

          if (timer.timeLeft <= 0)
          {
            ref var entity = ref _timerFilters.GetEntity(index);
            entity.Del<TimerComponent>();
          }
      }
    }
  }
}
