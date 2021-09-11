using Zenject;

namespace Kidvibe.App
{
  public class ZenjectPrefabInit : MonoInstaller
  {
    public override void InstallBindings()
    {
      Container.Bind<AppModel>().AsSingle();
    }
  }
}
