using Kidvibe.Assets.Utils;
using Kidvibe.Game.Timer.Pools;
using Kidvibe.GameData.Static.Configs.Player;
using Kidvibe.GameLogic.Player.State.Core;
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

      Container.Bind<GameContext>().FromInstance(Contexts.sharedInstance.game).AsSingle();
    }
  }
}