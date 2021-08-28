using Entitas;
using Kidvibe.Assets.ECS.Components.Player.State;
using UnityEngine;

namespace Kidvibe.Assets.ECS.Systems.Player
{
  public class PlayerStateSystem : IExecuteSystem
  {
    private readonly IGroup<GameEntity> States;

    public PlayerStateSystem(GameContext context)
    {
      States = context.GetGroup(
        GameMatcher.AllOf(GameMatcher.State,
          GameMatcher.Input));
    }

    public void Execute()
    {
      foreach (var entity in States)
      {
        if (entity.input.direction == Vector2.zero)
          entity.state.state.Set<IdleState>(entity);
      }
    }
  }
}
