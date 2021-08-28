using Kidvibe.Assets.GameData.Static.Configs.Player;
using Zenject;

namespace Kidvibe.Assets.ECS.Components.Player.State
{
  public class RunState : PlayerState
  {
    [Inject] private readonly PlayerMovementConfigs MovementConfigs;

    public override void OnAdd(GameEntity entity)
    {
      entity.AddRun(MovementConfigs.WalkSpeed);
      entity.ReplaceRun(MovementConfigs.RunSpeed);
      entity.ReplaceDash(MovementConfigs.DashConfigs.Power,
        MovementConfigs.DashConfigs.Duration);
    }

    public override void OnRemove(GameEntity entity)
    {
      entity.RemoveRun();
    }
  }
}
