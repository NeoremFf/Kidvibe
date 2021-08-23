using Kidvibe.Assets.ECS.Components;
using Leopotam.Ecs;
using UnityEngine;

namespace Kidvibe.Assets.ECS
{
  public class InputSystem : IEcsRunSystem
  {
    private EcsFilter<InputComponent> _inputFilters;

    public void Run()
    {
      if (_inputFilters.IsEmpty())
        return;

      var input = new Vector2(Input.GetAxisRaw("Horizontal"),
        Input.GetAxisRaw("Vertical"));
      var dash = Input.GetKeyDown(KeyCode.LeftShift);

      Execute(input, dash);
    }

    private void Execute(Vector2 input, bool dash)
    {
      foreach (var index in _inputFilters)
      {
        ref var inputComponent = ref _inputFilters.Get1(index);

        inputComponent.direction = input;
        inputComponent.dash = dash;
      }
    }
  }
}