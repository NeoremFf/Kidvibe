using Entitas;

namespace Kidvibe.Assets.ECS.Systems.Player.Dash
{
  public class DashSystem : IExecuteSystem
  {
    private readonly IGroup<GameEntity> Dashes;

    public DashSystem(GameContext context)
    {
      Dashes = context.GetGroup(
        GameMatcher.AllOf(GameMatcher.Rigidbody, GameMatcher.Dash));
    }

    public void Execute()
    {
      foreach (var entity in Dashes)
      {
        // entity.rigidbody.rigidbody.velocity = entity.input.direction
      }
    }
  }
}
