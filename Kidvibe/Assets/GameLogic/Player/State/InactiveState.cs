using Kidvibe.GameLogic.Player.State.Core;
using Kidvibe.Utils;

namespace Kidvibe.GameLogic.Player.State
{
  public class InactiveState : PlayerState
  {
    public override void OnAdd()
    {
      logger.LogWithTag(LogTag.State, LogColor.Green, $"Added {nameof(InactiveState)}");
    }

    public override void OnRemove()
    {
      logger.LogWithTag(LogTag.State, LogColor.Green, $"Removed {nameof(InactiveState)}");
    }
  }
}
