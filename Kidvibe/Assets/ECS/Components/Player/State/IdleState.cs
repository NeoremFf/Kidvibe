using Kidvibe.ECS.Components.Player.State.Core;

namespace Kidvibe.ECS.Components.Player.State
{
  public class IdleState : PlayerState
  {
    public override void OnAdd()
    {
      entity.isMovable = true;

      logger.Log("Add movable");
    }

    public override void OnRemove()
    {
      entity.isMovable = false;
      
      logger.Log("Remove movable");
    }
  }
}
