using Kidvibe.Assets.ECS.Components;
using Leopotam.Ecs;
using UnityEngine;

namespace Kidvibe.Assets.ECS.Systems
{
  public class MovePlayerSystem : IEcsRunSystem
  {
    private EcsFilter<MovableComponent, InputComponent> _moveFilters = null;

    public void Run()
    {
      if (_moveFilters.IsEmpty())
        return;

      Execute();
    }

    private void Execute()
    {
      foreach (var index in _moveFilters)
      {
        ref var movement = ref _moveFilters.Get1(index);
        ref var input = ref _moveFilters.Get2(index);

        movement.rigidbody.velocity = !input.dash
          ? input.direction * movement.speed
          : Vector2.zero;
      }
    }
  }
}