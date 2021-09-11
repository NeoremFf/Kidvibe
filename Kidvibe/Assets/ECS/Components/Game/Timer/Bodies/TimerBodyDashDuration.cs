using Kidvibe.Assets.Utils.Exceptions;
using Kidvibe.ECS.Components.Player.State;
using Kidvibe.GameData.Static.Configs.Player;
using Zenject;

namespace Kidvibe.ECS.Components.Game.Timer.Bodies
{
  public class TimerBodyDashDuration : TimerBody
  {
    [Inject] private readonly PlayerDashConfigs _configs;

    public override void Run()
    {
      base.Run(_configs.Duration);
    }

    protected override void OnExpired()
    {
      base.OnExpired();

      logger.Log("Dash Duration has been expired!");

      if (!entity.hasState)
      {
        logger.LogErrorWithMessage(new EcsComponentMissingException(nameof(StateComponent)),
          $"Missing {nameof(StateComponent)} component in {nameof(TimerBodyDashDuration)}");

        return;
      }

      entity.state.currentState.Set<IdleState>();
    }
  }
}
