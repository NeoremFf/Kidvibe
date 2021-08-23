using Kidvibe.Assets.ECS.Systems;
using Kidvibe.Assets.ECS.Systems.Tools;
using Leopotam.Ecs;
using UnityEngine;
using Zenject;

namespace Kidvibe.Assets.ECS.MainGame
{
  public class MainGameWorldLoader : MonoBehaviour
  {
    private EcsWorld _world;
    private EcsSystems _systems;

    private DiContainer _diContainer;

    [Inject]
    public void Init(DiContainer diContainer)
    {
      _diContainer = diContainer;
    }

    private void Start()
    {
      _world = new EcsWorld();
      _systems = new EcsSystems(_world);

      _systems.Add(_diContainer.Instantiate<MainGameInitialSystem>());

      _systems.Add(_diContainer.Instantiate<InputSystem>());
      _systems.Add(_diContainer.Instantiate<MovePlayerSystem>());
      _systems.Add(_diContainer.Instantiate<DashSystem>());
      _systems.Add(_diContainer.Instantiate<TimerSystem>());

      _systems.Init();
    }

    private void Update() =>
      _systems.Run();

    private void OnDestroy()
    {
      _systems.Destroy();
      _world.Destroy();
    }
  }
}