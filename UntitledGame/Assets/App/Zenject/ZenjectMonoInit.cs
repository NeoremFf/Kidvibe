using Kidvibe.Assets.Utils;
using Zenject;

public class ZenjectMonoInit : MonoInstaller
{
    public override void InstallBindings()
    {
      Container.Bind<ILogger>().To<Logger>().AsSingle();
    }
}