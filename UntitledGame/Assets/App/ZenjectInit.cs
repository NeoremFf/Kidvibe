using Kidvibe.Assets.Utils;
using Zenject;

public class ZenjectInit : MonoInstaller
{
  public override void InstallBindings()
  {
    // Container.Bind<ILogger>().To<Logger>().AsSingle();
  }
}
