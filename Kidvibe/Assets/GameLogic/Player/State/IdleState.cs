using Kidvibe.GameLogic.Player.State.Core;
using Kidvibe.Utils;

namespace Kidvibe.GameLogic.Player.State
{
  public class IdleState : PlayerState
  {
    public override void OnAdd()
    {
      entity.isMovable = true;

      logger.LogWithTag(LogTag.State, LogColor.Green, "Added Movable");
    }

    public override void OnRemove()
    {
      entity.isMovable = false;
      
      logger.LogWithTag(LogTag.State, LogColor.Green, "Removed movable");
    }
  }
}
