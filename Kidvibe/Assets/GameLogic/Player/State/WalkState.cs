using Kidvibe.GameData.Static.Configs.Player;
using Kidvibe.GameLogic.Player.State.Core;
using Kidvibe.Utils;
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

      logger.LogWithTag(LogTag.State, LogColor.Green, $"Added {nameof(WalkState)}");

    }

    public override void OnRemove()
    {
      entity.RemoveWalk();
      entity.isDashable = false;

      logger.LogWithTag(LogTag.State, LogColor.Green, $"Removed {nameof(WalkState)}");
    }
  }
}
