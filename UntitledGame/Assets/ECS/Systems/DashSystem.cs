using Kidvibe.Assets.ECS.Components;
using Kidvibe.Assets.ECS.Components.Player;
using Leopotam.Ecs;
using UnityEngine;
using Zenject;
using ILogger = Kidvibe.Assets.Utils.ILogger;

namespace Kidvibe.Assets.ECS.Systems
{
  public class DashSystem : IEcsRunSystem
  {
    [Inject] private readonly ILogger Logger;

    private EcsFilter<DashableComponent, InputComponent>.Exclude<CdComponent<DashableComponent> _dashFilters;

    public void Run()
    {
      if (_dashFilters.IsEmpty())
        return;

      Execute();
    }

    private void Execute()
    {
      foreach (var index in _dashFilters)
      {
        ref var input = ref _dashFilters.Get2(index);
        ref var dash = ref _dashFilters.Get1(index);

        _dashFilters.GetEntity().id

        if (dash.can)
        {
          if (!dash.run)
          {
            if (input.dash && input.direction.magnitude > 0)
            {
              dash.rigidbody.velocity = input.direction * dash.power;

              dash.timer = dash.duration;
              dash.run = true;
              dash.can = false;
            }
          }
          else
          {
            dash.timer -= Time.deltaTime;
          }
        }
        else
        {
          if (dash.timer <= 0)
          {
            dash.can = true;
          }
          else
          {
            dash.timer -= Time.deltaTime;
          }
        }
      }
    }
  }
}