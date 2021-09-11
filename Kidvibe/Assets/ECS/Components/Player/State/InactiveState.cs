using Kidvibe.ECS.Components.Player.State.Core;

namespace Kidvibe.ECS.Components.Player.State
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
