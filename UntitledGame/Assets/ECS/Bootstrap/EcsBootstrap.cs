using Kidvibe.Assets.ECS.Systems.Inputs;
using Kidvibe.Assets.ECS.Systems.Player;
using Kidvibe.Assets.ECS.Systems.Tools;
using UnityEngine;
using Zenject;

namespace Kidvibe.Assets.ECS.Bootstrap
{
  public class EcsBootstrap : MonoBehaviour
  {
    private MainGameFeatures systems;

    [Inject] private GameContext _gameContext;
    [Inject] private DiContainer _diContainer;

    private void Awake() =>
      systems = new MainGameFeatures(_gameContext, _diContainer);

    private void Start() =>
      systems.Initialize();

    private void Update()
    {
      systems.Execute();
      systems.Cleanup();
    }

    private void OnDestroy() =>
      systems.TearDown();
  }

  public class MainGameFeatures : Feature
  {
    public MainGameFeatures(GameContext context, DiContainer diContainer)
    {
      Add(diContainer.Instantiate<InputSystem>());
      Add(diContainer.Instantiate<MoveablePlayerSystem>());
      Add(diContainer.Instantiate<MovePlayerSystem>());
      Add(diContainer.Instantiate<DashableSystem>());
      Add(diContainer.Instantiate<DashSystem>());
      Add(diContainer.Instantiate<PlayerStateSystem>());
      Add(diContainer.Instantiate<TimersSystem>());
    }
  }
}