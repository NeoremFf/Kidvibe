using Kidvibe.GameData.Static.Configs.Player;
using Kidvibe.GameLogic.Player.State.Core;
using Zenject;

namespace Kidvibe.GameLogic.Player.State
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
