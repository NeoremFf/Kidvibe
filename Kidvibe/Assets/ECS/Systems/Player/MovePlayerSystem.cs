using Entitas;
using Kidvibe.GameLogic.Player.State;
using UnityEngine;

namespace Kidvibe.ECS.Systems.Player
{
  public class MovePlayerSystem : IExecuteSystem
  {
    private readonly IGroup<GameEntity> Inputs;
    private readonly IGroup<GameEntity> MoveType;
    
    public MovePlayerSystem(GameContext context)
    {
      Inputs = context.GetGroup(
        GameMatcher.AllOf(GameMatcher.Input,
          GameMatcher.Rigidbody,
          GameMatcher.State));
      MoveType = context.GetGroup(
        GameMatcher.AnyOf(GameMatcher.Walk,
          GameMatcher.Run));
    }

    public void Execute()
    {
      foreach (var entity in Inputs)
      foreach (var moveType in MoveType.GetEntities())
      {
        if (entity.input.walk)
          entity.state.currentState.Set<WalkState>();
        else
          entity.state.currentState.Set<RunState>();

        var speed = moveType.hasWalk ? moveType.walk.speed : moveType.run.speed;
        var direction = entity.input.direction;

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
          if (entity.input.walk)
            entity.state.currentState.Set<WalkState>();
          else
            entity.state.currentState.Set<RunState>();
        }

        entity.rigidbody.rigidbody.velocity = Vector2.zero; // for reset velocity after dash
      }
    }
  }
}
