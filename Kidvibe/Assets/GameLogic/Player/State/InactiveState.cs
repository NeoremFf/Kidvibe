using Kidvibe.GameLogic.Player.State.Core;

namespace Kidvibe.GameLogic.Player.State
{
  public class InactiveState : PlayerState
  {
    public override void OnAdd()
    {
      logger.Log("Create " + nameof(InactiveState));
    }

    public override void OnRemove()
    {
      logger.Log("Remove " + nameof(InactiveState));
    }
  }
}
