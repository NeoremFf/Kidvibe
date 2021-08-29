using Kidvibe.Assets.GameData.Static.Configs.Player;
using Zenject;

namespace Kidvibe.Assets.ECS.Components.Player.State
{
  public class RunState : PlayerState
  {
    [Inject] private readonly PlayerMovementConfigs MovementConfigs;
    [Inject] private readonly PlayerDashConfigs DashConfigs;

    public override void OnAdd()
    {
      entity.AddRun(MovementConfigs.WalkSpeed);
      entity.ReplaceRun(MovementConfigs.RunSpeed);
      entity.ReplaceDash(DashConfigs.Power);
    }

    public override void OnRemove()
    {
      entity.RemoveRun();
    }
  }
}
