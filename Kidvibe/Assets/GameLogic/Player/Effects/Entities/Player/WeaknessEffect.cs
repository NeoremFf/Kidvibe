using Kidvibe.ECS.Components.Player;
using Kidvibe.GameData.Static.Configs.Player;
using Kidvibe.GameLogic.Player.Effects.Core;
using Kidvibe.Utils;
using Kidvibe.Utils.Exceptions;
using Zenject;

namespace Kidvibe.GameLogic.Player.Effects.Entities.Player
{
  public class WeaknessEffect : EffectCore
  {
    [Inject] private readonly PlayerMovementConfigs _configs;

    protected override void Applied()
    {
      logger.LogWithTag(LogTag.Effect, LogColor.Green, $"{nameof(WeaknessEffect)} has been applied.");

      if (!entity.hasRunSpeed)
      {
        logger.ErrorWithMessage(new EcsComponentMissingException(nameof(RunSpeedComponent)),
          $"Missing {nameof(RunSpeedComponent)} component in {nameof(WeaknessEffect)}");
        
        return;
      }

      entity.isDashable = false;
      entity.runSpeed.ChangeRunSpeed(_configs.WeaknessRunSpeed);
    }

    protected override void Disabled()
    {
      logger.LogWithTag(LogTag.Effect, LogColor.Green, $"{nameof(WeaknessEffect)} has been disabled.");
      
      if (!entity.hasRunSpeed)
      {
        logger.ErrorWithMessage(new EcsComponentMissingException(nameof(RunSpeedComponent)),
          $"Missing {nameof(RunSpeedComponent)} component in {nameof(WeaknessEffect)}");
        
        return;
      }

      entity.isDashable = true;
      entity.runSpeed.ChangeRunSpeed(_configs.RunSpeed);
    }
  }
}