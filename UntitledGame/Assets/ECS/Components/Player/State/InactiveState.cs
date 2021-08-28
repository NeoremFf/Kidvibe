namespace Kidvibe.Assets.ECS.Components.Player.State
{
  public class InactiveState : PlayerState
  {
    public override void OnAdd(GameEntity entity)
    {
      Logger.Log("Create " + nameof(InactiveState));
    }

    public override void OnRemove(GameEntity entity)
    {
      Logger.Log("Remove " + nameof(InactiveState));
    }
  }
}
