using Entitas;
using Kidvibe.Assets.Utils;
using Kidvibe.GameLogic.Player.State;
using Kidvibe.GameLogic.Timer.Bodies;
using Zenject;

namespace Kidvibe.ECS.Systems.Player
{
  public class DashSystem : IExecuteSystem
  {
    private readonly IGroup<GameEntity> _dashes;
    
    public DashSystem(GameContext context)
    {
      _dashes = context.GetGroup(
        GameMatcher.AllOf(GameMatcher.Rigidbody,
          GameMatcher.Dash));
    }

    public void Execute()
    {
      foreach (var entity in _dashes)
      {
        entity.rigidbody.rigidbody.velocity = entity.dash.direction * entity.dash.power;
      }
    }
  }

  public class DashableSystem : IExecuteSystem
  {
    private readonly IGroup<GameEntity> _dashable;

    [Inject] private readonly ILogger _logger;

    public DashableSystem(GameContext context)
    {
      _dashable = context.GetGroup(
        GameMatcher.AllOf(GameMatcher.Input,
          GameMatcher.Dashable,
          GameMatcher.DashCharges,
          GameMatcher.State,
          GameMatcher.Timers));
    }

    public void Execute()
    {
      foreach (var entity in _dashable.GetEntities())
      {
        if (entity.input.dash && entity.dashCharges.count > 0)
        {
          entity.state.currentState.Set<DashState>(entity.input.direction);

          _logger.TemporaryDebug("<color=red>Remove</color>");
          _logger.TemporaryDebug($"Current count of charges: {entity.dashCharges.count}");
        }
      }
    }
  }
}
