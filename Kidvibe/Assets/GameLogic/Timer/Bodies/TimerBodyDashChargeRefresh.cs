using Kidvibe.Assets.Utils.Exceptions;
using Kidvibe.ECS.Components;
using Kidvibe.ECS.Components.Player;
using Kidvibe.GameData.Static.Configs.Player;
using Kidvibe.GameLogic.Player.State;
using Zenject;

namespace Kidvibe.GameLogic.Timer.Bodies
{
  public class TimerBodyDashChargeRefresh : DelayTimerBody, IRepeatableTimerWithDelay
  {
    [Inject] private readonly PlayerDashConfigs _configs;

    public void Repeat()
    {
      logger.Log($"<color=blue>[TIMER]</color> {typeof(TimerBodyDashChargeRefresh)} is repeating!");
      
      RunDelay();
    }
    
    public override void RunDelay()
    {
      base.RunDelay(_configs.ChargeRefreshDelayTime);
    }

    public override void Run()
    {
      Run(_configs.ChargeRefreshTime);
    }

    protected override void OnExpired()
    {
      base.OnExpired();

      if (isDelay)
      {
        isDelay = false;
        
        return;
      }
      
      logger.Log($"<color=blue>[TIMER]</color> {typeof(TimerBodyDashChargeRefresh)} has been expired!");

      if (!entity.hasDashCharges)
      {
        logger.ErrorWithMessage(new EcsComponentMissingException(nameof(StateComponent)),
          $"Missing {nameof(StateComponent)} component in {nameof(TimerBodyDashDuration)}");

        return;
      }
      
      if (!entity.hasTimers)
      {
        logger.ErrorWithMessage(new EcsComponentMissingException(nameof(TimersComponent)),
          $"Missing {nameof(TimersComponent)} component in {nameof(TimerBodyDashChargeRefresh)}");

        return;
      }

      if (entity.dashCharges.count != entity.dashCharges.maxCount)
      {
        entity.dashCharges.Add();
       
        logger.TemporaryDebug("<color=green>Remove</color>");
        logger.TemporaryDebug($"Current count of charges: {entity.dashCharges.count}");
        
        Repeat();
      }
    }
  }
}