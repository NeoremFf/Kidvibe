using Kidvibe.GameData.Static.Configs.Player;
using Kidvibe.GameLogic.Player.State.Core;
using Zenject;

namespace Kidvibe.GameLogic.Player.State
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
