using Entitas;
using Kidvibe.Assets.ECS.Components.Player.State;

namespace Kidvibe.Assets.ECS.Systems.Player
{
  public class PlayerStateSystem : IExecuteSystem
  {
    private readonly IGroup<GameEntity> _states;

    public PlayerStateSystem(GameContext context)
    {
      _states = context.GetGroup(
        GameMatcher.AllOf(GameMatcher.State,
          GameMatcher.Rigidbody,
          GameMatcher.Input));
    }

    public void Execute()
    {
      foreach (var entity in _states)
      {
        entity.state.stateCore.Set<InactiveState>(entity);
      }
    }
  }
}
