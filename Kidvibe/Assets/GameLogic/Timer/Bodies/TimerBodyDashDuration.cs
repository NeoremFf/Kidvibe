using Kidvibe.ECS.Components.Player;
using Kidvibe.GameData.Static.Configs.Player;
using Kidvibe.GameLogic.Player.State;
using Kidvibe.Utils;
using Kidvibe.Utils.Exceptions;
using Zenject;

namespace Kidvibe.GameLogic.Timer.Bodies
{
  public class TimerBodyDashDuration : TimerBody
  {
    [Inject] private readonly PlayerDashConfigs _configs;

    public override void Run()
    {
      Run(_configs.Duration);
    }

    protected override void Expired()
    {
      base.Expired();

      logger.LogWithTag(LogTag.Timer, LogColor.Orange, $"{nameof(TimerBodyDashDuration)} has been expired!");

      if (!entity.hasState)
      {
        logger.ErrorWithMessage(new EcsComponentMissingException(nameof(StateComponent)),
          $"Missing {nameof(StateComponent)} component in {nameof(TimerBodyDashDuration)}");

        return;
      }

      entity.state.currentState.Set<IdleState>();
    }
  }
}
