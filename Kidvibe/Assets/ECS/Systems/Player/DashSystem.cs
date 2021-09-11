using Entitas;
using Kidvibe.Assets.Utils;
using Kidvibe.ECS.Components.Game.Timer.Bodies;
using Kidvibe.ECS.Components.Player.State;
using Zenject;

namespace Kidvibe.ECS.Systems.Player
{
  public class DashSystem : IExecuteSystem
  {
    private readonly IGroup<GameEntity> _dashes;

    [Inject] private readonly ILogger _logger;

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

        _logger.Log("Dash is run!");
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
        GameMatcher.AllOf(
          GameMatcher.Input,
          GameMatcher.Dashable,
          GameMatcher.State,
          GameMatcher.Timers));
    }

    public void Execute()
    {
      foreach (var entity in _dashable.GetEntities())
      {
        if (entity.input.dash)
        {
          entity.state.currentState.Set<DashState>(entity.input.direction);
          entity.timers.Set<TimerBodyDashDuration>();

          _logger.Log("Set Dash");
        }
      }
    }
  }
}
