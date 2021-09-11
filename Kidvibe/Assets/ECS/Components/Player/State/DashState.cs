using Kidvibe.ECS.Components.Player.State.Core;
using Kidvibe.GameData.Static.Configs.Player;
using UnityEngine;
using Zenject;

namespace Kidvibe.ECS.Components.Player.State
{
  public class DashState : PlayerState
  {
    [Inject] private readonly PlayerDashConfigs _dashConfigs;

    private Vector2 _direction;

    public override void OnAdd()
    {
      logger.Log("Set " + nameof(DashState));
      
      entity.AddDash(_dashConfigs.Power, _direction);
    }

    public override void OnAdd(object data)
    {
      if (data is Vector2 direction)
        _direction = direction;
      
      OnAdd();
    }

    public override void OnRemove()
    {
      logger.Log("Remove " + nameof(DashState));

      entity.RemoveDash();
    }
  }
}
