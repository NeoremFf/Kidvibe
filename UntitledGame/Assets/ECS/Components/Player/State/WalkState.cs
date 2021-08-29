using Kidvibe.Assets.GameData.Static.Configs.Player;
using Zenject;

namespace Kidvibe.Assets.ECS.Components.Player.State
{
  public class WalkState : PlayerState
  {
    [Inject] private readonly PlayerMovementConfigs MovementConfigs;

    public override void OnAdd()
    {
      entity.AddWalk(MovementConfigs.WalkSpeed);
      entity.isDashable = true;

      Logger.Log("Add walk state");
    }

    public override void OnRemove()
    {
      entity.RemoveWalk();
      entity.isDashable = false;

      Logger.Log("Remove walk state");
    }
  }
}
