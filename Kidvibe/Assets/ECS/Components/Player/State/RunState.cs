using Kidvibe.ECS.Components.Player.State.Core;
using Kidvibe.GameData.Static.Configs.Player;
using Zenject;

namespace Kidvibe.ECS.Components.Player.State
{
  public class RunState : PlayerState
  {
    [Inject] private readonly PlayerMovementConfigs _movementConfigs;

    public override void OnAdd()
    {
      entity.AddRun(_movementConfigs.RunSpeed);
      entity.isDashable = true;
      
      logger.Log("Add run state");
    }

    public override void OnRemove()
    {
      entity.RemoveRun();
      entity.isDashable = false;

      logger.Log("Remove run state");
    }
  }
}
