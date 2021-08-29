using Entitas;
using Kidvibe.Assets.ECS.Components.Game.Timer;
using Kidvibe.Assets.ECS.Components.Game.Timer.Bodies;
using Kidvibe.Assets.ECS.Components.Player.State;
using Kidvibe.Assets.Utils;
using Zenject;

namespace Kidvibe.Assets.ECS.Systems.Player
{
  public class DashSystem : IExecuteSystem
  {
    private readonly IGroup<GameEntity> Dashes;

    [Inject] private readonly ILogger Logger;

    public DashSystem(GameContext context)
    {
      Dashes = context.GetGroup(
        GameMatcher.AllOf(GameMatcher.Rigidbody,
          GameMatcher.Input,
          GameMatcher.Dash));
    }

    public void Execute()
    {
      foreach (var entity in Dashes)
      {
        entity.rigidbody.rigidbody.velocity = entity.input.direction * entity.dash.power;

        Logger.Log("Dash is run!");
      }
    }
  }

  public class DashableSystem : IExecuteSystem
  {
    private readonly IGroup<GameEntity> Dashable;

    [Inject] private readonly ILogger Logger;

    public DashableSystem(GameContext context)
    {
      Dashable = context.GetGroup(
        GameMatcher.AllOf(GameMatcher.Input,
            GameMatcher.Dashable,
            GameMatcher.State,
            GameMatcher.Timers));
    }

    public void Execute()
    {
      foreach (var entity in Dashable.GetEntities())
      {
        if (entity.input.dash)
        {
          entity.state.currentState.Set<DashState>();
          entity.timers.Set<TimerBodyDashDuration>();

          Logger.Log("Set Dash");
        }
      }
    }
  }
}
