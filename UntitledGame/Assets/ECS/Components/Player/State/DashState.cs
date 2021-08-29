using Kidvibe.Assets.GameData.Static.Configs.Player;
using Zenject;

namespace Kidvibe.Assets.ECS.Components.Player.State
{
  public class DashState : PlayerState
  {
    [Inject] private readonly PlayerDashConfigs DashConfigs;

    public override void OnAdd()
    {
      Logger.Log("Set " + nameof(DashState));
      
      entity.AddDash(DashConfigs.Power);
    }

    public override void OnRemove()
    {
      Logger.Log("Remove " + nameof(DashState));

      entity.RemoveDash();
    }
  }
}
