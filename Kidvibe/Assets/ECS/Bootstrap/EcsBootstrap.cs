using Kidvibe.ECS.Systems.Game.Timer;
using Kidvibe.ECS.Systems.Inputs;
using Kidvibe.ECS.Systems.Player;
using UnityEngine;
using Zenject;

namespace Kidvibe.ECS.Bootstrap
{
  public class EcsBootstrap : MonoBehaviour
  {
    private MainGameFeatures _systems;

    [Inject] private GameContext _gameContext;
    [Inject] private DiContainer _diContainer;

    private void Awake() =>
      _systems = new MainGameFeatures(_gameContext, _diContainer);

    private void Start() =>
      _systems.Initialize();

    private void Update()
    {
      _systems.Execute();
      _systems.Cleanup();
    }

    private void OnDestroy() =>
      _systems.TearDown();
  }

  public class MainGameFeatures : Feature
  {
    public MainGameFeatures(GameContext context, DiContainer diContainer)
    {
      Add(diContainer.Instantiate<GameInputSystem>());
      Add(diContainer.Instantiate<MoveablePlayerSystem>());
      Add(diContainer.Instantiate<MovePlayerSystem>());
      Add(diContainer.Instantiate<DashableSystem>());
      Add(diContainer.Instantiate<DashSystem>());
      Add(diContainer.Instantiate<TimersSystem>());
    }
  }
}