using Entitas;
using Kidvibe.Assets.GameData.Static.Configs.Player;
using Zenject;

namespace Kidvibe.Assets.ECS.Systems.Player
{
  public class MovePlayerSystem : IExecuteSystem
  {
    private readonly IGroup<GameEntity> _inputs;

    [Inject] private readonly PlayerMovementConfigs Configs;

    public MovePlayerSystem(GameContext context)
    {
      _inputs = context.GetGroup(
        GameMatcher.AllOf(GameMatcher.Rigidbody,
          GameMatcher.Input));
    }

    public void Execute()
    {
      foreach (var entity in _inputs)
      {
        //entity.rigidbody.rigidbody.velocity = entity.input.direction * Configs.MoveSpeed;
      }
    }
  }
}
