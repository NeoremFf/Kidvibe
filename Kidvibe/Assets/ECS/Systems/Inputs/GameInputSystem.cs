using Entitas;
using UnityEngine;

namespace Kidvibe.ECS.Systems.Inputs
{
  public class GameInputSystem : IExecuteSystem
  {
    private readonly IGroup<GameEntity> _inputs;

    public GameInputSystem(GameContext context)
    {
      _inputs = context.GetGroup(
        GameMatcher.Input);
    }

    public void Execute()
    {
      foreach (var entity in _inputs)
      {
        entity.input.direction = new Vector2(
          Input.GetAxisRaw("Horizontal"),
          Input.GetAxisRaw("Vertical"))
          .normalized;
        entity.input.walk = Input.GetKey(KeyCode.Space);
        entity.input.dash = Input.GetKeyDown(KeyCode.LeftShift);
      }
    }
  }
}
