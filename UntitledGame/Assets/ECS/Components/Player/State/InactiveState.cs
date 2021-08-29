namespace Kidvibe.Assets.ECS.Components.Player.State
{
  public class InactiveState : PlayerState
  {
    public override void OnAdd()
    {
      Logger.Log("Create " + nameof(InactiveState));
    }

    public override void OnRemove()
    {
      Logger.Log("Remove " + nameof(InactiveState));
    }
  }
}
