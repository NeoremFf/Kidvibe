using Entitas;
using Kidvibe.Assets.GameData.Static.Configs.Player;
using UnityEngine;
using Zenject;

namespace Kidvibe.Assets.ECS.Systems.Player
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
          GameMatcher.Movable));
      MoveType = context.GetGroup(
        GameMatcher.AnyOf(GameMatcher.Walk,
          GameMatcher.Run));
    }

    public void Execute()
    {
      foreach (var entity in Inputs)
      foreach (var moveType in MoveType)
      {
        Debug.Log("Walk");

        var speed = moveType.hasWalk ? moveType.walk.speed : moveType.run.speed;
        entity.rigidbody.rigidbody.velocity = entity.input.direction * speed;
      }
    }
  }

  public class MoveablePlayerSystem : IExecuteSystem
  {
    private readonly IGroup<GameEntity> Moveable;

    [Inject] private readonly PlayerMovementConfigs Configs;

    public MoveablePlayerSystem(GameContext context)
    {
      Moveable = context.GetGroup(
        GameMatcher.AllOf(GameMatcher.Input,
          GameMatcher.Movable));
    }

    public void Execute()
    {
      foreach (var entity in Moveable)
      {
        if (!entity.isMovable
            || entity.hasWalk
            || entity.hasRun)
          continue;
        
        if (entity.input.direction != Vector2.zero)
        {
          entity.AddWalk(Configs.WalkSpeed);

          Debug.Log("Set walk");
        }
      }
    }
  }
}
