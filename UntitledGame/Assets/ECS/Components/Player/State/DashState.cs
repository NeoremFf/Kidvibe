namespace Kidvibe.Assets.ECS.Components.Player.State
{
  public class DashState : PlayerState
  {
    public override void OnAdd(GameEntity entity)
    {
      Logger.Log("Create " + nameof(DashState));
      // entity.AddDash(); TODO
    }

    public override void OnRemove(GameEntity entity)
    {
      Logger.Log("Remove " + nameof(DashState));
      entity.RemoveDash();
    }
  }
}
