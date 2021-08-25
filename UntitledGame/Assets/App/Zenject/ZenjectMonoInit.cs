using Kidvibe.Assets.ECS.Components.Player.State;
using Kidvibe.Assets.GameData.Static.Configs.Player;
using Kidvibe.Assets.Utils;
using Zenject;

namespace Kidvibe.Assets.App.Zenject
{
  public class ZenjectMonoInit : MonoInstaller
  {
    public override void InstallBindings()
    {
      Container.Bind<ILogger>().To<Logger>().AsSingle();
      Container.Bind<PlayerMovementConfigs>().AsSingle();
      Container.Bind<PlayerStateCore>().AsSingle();
      Container.Bind<GameContext>().FromInstance(Contexts.sharedInstance.game).AsSingle();
    }
  }
}