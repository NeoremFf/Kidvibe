using System.Data;
using Entitas;
using Kidvibe.ECS.Components.Player.State;
using UnityEngine;
using Zenject;
using ILogger = Kidvibe.Assets.Utils.ILogger;

namespace Kidvibe.Assets.ECS.Systems.Player
{
  public class MovePlayerSystem : IExecuteSystem
  {
    private readonly IGroup<GameEntity> Inputs;
    private readonly IGroup<GameEntity> MoveType;

    [Inject] private readonly ILogger Logger;

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
        Logger.Log("Walk");

        var speed = moveType.hasWalk ? moveType.walk.speed : moveType.run.speed;

        var direction = entity.input.direction;

        if (direction == Vector2.zero)
          entity.state.currentState.Set<IdleState>();

        // todo add check that user wish run or walk

        entity.rigidbody.rigidbody.velocity = entity.input.direction * speed;
      }
    }
  }

  public class MoveablePlayerSystem : IExecuteSystem
  {
    private readonly IGroup<GameEntity> _moveable;

    [Inject] private readonly ILogger _logger;

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
          entity.state.currentState.Set<WalkState>();

          _logger.Log("Set walk");
        }

        entity.rigidbody.rigidbody.velocity = Vector2.zero;
      }
    }
  }
}
