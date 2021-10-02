using Kidvibe.GameData.Dynamic.Game.Player;
using Kidvibe.GameLogic.Player.Effects.Entities.Player;
using Kidvibe.GameLogic.Player.State.Core;
using Kidvibe.GameLogic.Timer.Bodies;
using Kidvibe.Utils;
using UnityEngine;
using Zenject;

namespace Kidvibe.GameLogic.Player.State
{
  public class DashState : PlayerState
  {
    [Inject] private PlayerWrapper _wrapper;

    private Vector2 _direction;

    public override void OnAdd()
    {
      logger.LogWithTag(LogTag.State, LogColor.Green, $"Added {nameof(DashState)}");
      
      _wrapper.dashData.Remove();
      if (_wrapper.dashData.Count == 0)
        entity.effects.Apply<WeaknessEffect>();

      entity.timers.Delay<TimerBodyDashChargeRefresh>();
       
      entity.AddDash(_wrapper.dashData.Power, _direction);
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
