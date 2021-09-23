using Kidvibe.GameData.Static.Configs.Player;
using Kidvibe.GameLogic.Player.State.Core;
using Kidvibe.GameLogic.Timer.Bodies;
using Kidvibe.Utils;
using UnityEngine;
using Zenject;

namespace Kidvibe.GameLogic.Player.State
{
  public class DashState : PlayerState
  {
    [Inject] private readonly PlayerDashConfigs _dashConfigs;

    private Vector2 _direction;

    public override void OnAdd()
    {
      logger.LogWithTag(LogTag.State, LogColor.Green, $"Added {nameof(DashState)}");
      
      entity.dashCharges.Remove();
      entity.timers.Delay<TimerBodyDashChargeRefresh>();
      logger.TemporaryDebug("REMOVE CHARGE"); // todo remove
       
      entity.AddDash(_dashConfigs.Power, _direction);
      entity.timers.Set<TimerBodyDashDuration>();
    }

    public override void OnAdd(object data)
    {
      if (data is Vector2 direction)
        _direction = direction;
      
      OnAdd();
    }

    public override void OnRemove()
    {
      logger.LogWithTag(LogTag.State, LogColor.Green, $"Removed {nameof(DashState)}");

      entity.RemoveDash();
    }
  }
}
