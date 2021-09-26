using Kidvibe.GameLogic.Player.Effects.Entities.Player;
using Kidvibe.GameLogic.Player.State.Core;
using Kidvibe.Utils;

namespace Kidvibe.GameLogic.Player.State
{
  public class RunState : PlayerState
  {
    public override void OnAdd()
    {
      entity.isRun = true;

      if (!entity.effects.Has<WeaknessEffect>()) // TODO
        entity.isDashable = true;
      
      logger.LogWithTag(LogTag.State, LogColor.Green, $"Added {nameof(RunState)}");
    }

    public override void OnRemove()
    {
      entity.isRun = false;
      entity.isDashable = false;

      logger.LogWithTag(LogTag.State, LogColor.Green, $"Removed {nameof(RunState)}");
    }
  }
}
