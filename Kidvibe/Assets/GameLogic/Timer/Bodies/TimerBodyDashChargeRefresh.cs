using Kidvibe.ECS.Components;
using Kidvibe.ECS.Components.Player;
using Kidvibe.GameData.Static.Configs.Player;
using Kidvibe.GameLogic.Player.Effects.Entities.Player;
using Kidvibe.Utils;
using Kidvibe.Utils.Exceptions;
using Zenject;

namespace Kidvibe.GameLogic.Timer.Bodies
{
  public class TimerBodyDashChargeRefresh : TimerBody, IRepeatableTimerWithDelay
  {
    [Inject] private readonly PlayerDashConfigs _configs;

    public void Repeat(float delay)
    {
      logger.LogWithTag(LogTag.Timer, LogColor.Orange, 
        $"{typeof(TimerBodyDashChargeRefresh)} is repeating in {delay} seconds!");
      
      Delay(delay);
    }
    
    public override void Delay()
    {
      Delay(_configs.ChargeRefreshDelayTime);
    }

    public override void Run()
    {
      Run(_configs.ChargeRefreshTime);
    }

    protected override void Expired()
    {
      base.Expired();

      logger.LogWithTag(LogTag.Timer, LogColor.Orange, 
        $"{typeof(TimerBodyDashChargeRefresh)} has been expired!");

      if (!Validate())
        return;

      entity.dashCharges.Add();
      
      if (entity.dashCharges.count != entity.dashCharges.maxCount) 
        Repeat(_configs.ChargeRefreshDelayTime);
      else if (entity.effects.Has<WeaknessEffect>())
        entity.effects.Disable<WeaknessEffect>();
    }

    private bool Validate()
    {
      if (!entity.hasDashCharges)
      {
        logger.ErrorWithMessage(new EcsComponentMissingException(nameof(StateComponent)),
          $"Missing {nameof(StateComponent)} component in {nameof(TimerBodyDashDuration)}");

        return false;
      }
      
      if (!entity.hasTimers)
      {
        logger.ErrorWithMessage(new EcsComponentMissingException(nameof(TimersComponent)),
          $"Missing {nameof(TimersComponent)} component in {nameof(TimerBodyDashChargeRefresh)}");

        return false;
      }
      
      if (!entity.hasEffects)
      {
        logger.ErrorWithMessage(new EcsComponentMissingException(nameof(EffectsComponent)),
          $"Missing {nameof(EffectsComponent)} component in {nameof(TimerBodyDashChargeRefresh)}");

        return false;
      }

      return true;
    }
  }
}