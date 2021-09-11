using Kidvibe.ECS.Components.Player.State.Core;
using Kidvibe.GameData.Static.Configs.Player;
using Zenject;

namespace Kidvibe.ECS.Components.Player.State
{
  public class WalkState : PlayerState
  {
    [Inject] private readonly PlayerMovementConfigs _movementConfigs;

    public override void OnAdd()
    {
      entity.AddWalk(_movementConfigs.WalkSpeed);
      entity.isDashable = true;

      logger.Log("Add walk state");
    }

    public override void OnRemove()
    {
      entity.RemoveWalk();
      entity.isDashable = false;

      logger.Log("Remove walk state");
    }
  }
}
