using Kidvibe.Assets.ECS.Components.Player.State;
using Kidvibe.Assets.GameData.Static.Configs.Player;
using Kidvibe.Assets.Utils.Exceptions;
using Zenject;

namespace Kidvibe.Assets.ECS.Components.Game.Timer.Bodies
{
  public class TimerBodyDashDuration : TimerBody
  {
    [Inject] private readonly PlayerDashConfigs Configs;

    public TimerBodyDashDuration(GameEntity entity) : base(entity)
    {
    }

    public override void Run()
    {
      base.Run(Configs.Duration);
    }

    protected override void OnExpired()
    {
      base.OnExpired();

      Logger.Log("Dash Duration has been expired!");

      if (!entity.hasState)
      {
        Logger.LogErrorWithMessage(new EcsComponentMissingException(nameof(StateComponent)),
          $"Missing {nameof(StateComponent)} component in {nameof(TimerBodyDashDuration)}");

        return;
      }

      entity.state.currentState.Set<IdleState>();
    }
  }
}
