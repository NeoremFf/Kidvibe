namespace Kidvibe.Assets.ECS.Components.Player.State
{
  public class IdleState : PlayerState
  {
    public override void OnAdd()
    {
      entity.isMovable = true;

      Logger.Log("Add movable");
    }

    public override void OnRemove()
    {
      entity.isMovable = false;
      
      Logger.Log("Remove movable");
    }
  }
}
