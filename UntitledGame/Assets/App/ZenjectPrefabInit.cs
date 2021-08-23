using Zenject;

namespace Kidvibe.Assets.App
{
  public class ZenjectPrefabInit : MonoInstaller
  {
    public override void InstallBindings()
    {
      Container.Bind<AppModel>().AsSingle();
    }
  }
}
