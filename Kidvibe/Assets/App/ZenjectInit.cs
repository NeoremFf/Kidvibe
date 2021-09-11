using Zenject;

namespace Kidvibe.App
{
  public class ZenjectInit : MonoInstaller
  {
    public override void InstallBindings()
    {
      // Container.Bind<ILogger>().To<Logger>().AsSingle();
    }
  }
}
