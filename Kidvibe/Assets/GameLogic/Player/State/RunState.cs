using Kidvibe.GameData.Static.Configs.Player;
using Kidvibe.GameLogic.Player.State.Core;
using Kidvibe.Utils;
using Zenject;

namespace Kidvibe.GameLogic.Player.State
{
  public class RunState : PlayerState
  {
    [Inject] private readonly PlayerMovementConfigs _movementConfigs;

    public override void OnAdd()
    {
      entity.AddRun(_movementConfigs.RunSpeed);
      entity.isDashable = true;
      
      logger.LogWithTag(LogTag.State, LogColor.Green, $"Added {nameof(RunState)}");
    }

    public override void OnRemove()
    {
      entity.RemoveRun();
      entity.isDashable = false;

      logger.LogWithTag(LogTag.State, LogColor.Green, $"Removed {nameof(RunState)}");
    }
  }
}
