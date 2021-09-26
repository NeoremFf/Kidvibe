using Entitas;
using Kidvibe.GameLogic.Player.State;
using UnityEngine;

namespace Kidvibe.ECS.Systems.Player
{
  public class MovePlayerSystem : IExecuteSystem
  {
    private readonly IGroup<GameEntity> _inputs;
    private readonly IGroup<GameEntity> _move;
    
    public MovePlayerSystem(GameContext context)
    {
      _inputs = context.GetGroup(
        GameMatcher.AllOf(GameMatcher.Input,
          GameMatcher.Rigidbody,
          GameMatcher.State));
      _move = context.GetGroup(GameMatcher.AllOf(GameMatcher.Run,
        GameMatcher.RunSpeed));
    }

    public void Execute()
    {
      foreach (var entity in _inputs)
      foreach (var move in _move.GetEntities())
      {
        var direction = entity.input.direction;
        var speed = entity.input.walk ? move.runSpeed.walk : move.runSpeed.run;

        entity.rigidbody.rigidbody.velocity = entity.input.direction * speed;
        
        if (direction == Vector2.zero)
          entity.state.currentState.Set<IdleState>();
      }
    }
  }

  public class MoveablePlayerSystem : IExecuteSystem
  {
    private readonly IGroup<GameEntity> _moveable;
    
    public MoveablePlayerSystem(GameContext context)
    {
      _moveable = context.GetGroup(
        GameMatcher.AllOf(GameMatcher.Input,
          GameMatcher.Rigidbody,
          GameMatcher.Movable,
          GameMatcher.State));
    }

    public void Execute()
    {
      foreach (var entity in _moveable.GetEntities())
      {
        if (entity.input.direction != Vector2.zero)
        {
          entity.state.currentState.Set<RunState>();
        }

        entity.rigidbody.rigidbody.velocity = Vector2.zero; // for reset velocity after dash
      }
    }
  }
}
