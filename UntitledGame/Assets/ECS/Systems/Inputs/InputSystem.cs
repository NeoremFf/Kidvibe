using Entitas;
using UnityEngine;

namespace Kidvibe.Assets.ECS.Systems.Inputs
{
  public class InputSystem : IExecuteSystem
  {
    private readonly IGroup<GameEntity> Inputs;

    public InputSystem(GameContext context)
    {
      Inputs = context.GetGroup(
        GameMatcher.AllOf(GameMatcher.Input));
    }

    public void Execute()
    {
      foreach (var entity in Inputs)
      {
        entity.input.direction = new Vector2(Input.GetAxisRaw("Horizontal"),
          Input.GetAxisRaw("Vertical"));
        entity.input.dash = Input.GetKeyDown(KeyCode.LeftShift);
      }
    }
  }
}
