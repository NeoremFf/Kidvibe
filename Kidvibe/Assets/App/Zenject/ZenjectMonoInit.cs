using Kidvibe.GameData.Static.Configs.Player;
using Kidvibe.GameLogic.Player.Effects.Core;
using Kidvibe.GameLogic.Player.Effects.Pools;
using Kidvibe.GameLogic.Player.State.Core;
using Kidvibe.GameLogic.Timer.Pools;
using Kidvibe.Utils;
using Zenject;

namespace Kidvibe.App.Zenject
{
  public class ZenjectMonoInit : MonoInstaller
  {
    public override void InstallBindings()
    {
      Container.Bind<ILogger>().To<Logger>().AsSingle();

      Container.Bind<PlayerMovementConfigs>().AsSingle();
      Container.Bind<PlayerDashConfigs>().AsSingle();
      Container.Bind<PlayerStateCore>().AsSingle();

      Container.Bind<ITimerPool>().WithId("Player").To<PlayerTimerPool>().AsSingle();
      Container.Bind<IEffectPool>().WithId("Player").To<PlayerEffectsPool>().AsSingle();

      Container.Bind<GameContext>().FromInstance(Contexts.sharedInstance.game).AsSingle();
    }
  }
}