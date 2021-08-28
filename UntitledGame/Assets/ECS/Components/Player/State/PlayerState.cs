using System;
using System.Collections.Generic;
using Kidvibe.Assets.Utils;
using Zenject;

namespace Kidvibe.Assets.ECS.Components.Player.State
{
  public class PlayerStateCore
  {
    private PlayerState _state;
    private PlayerState _newState;

    private Dictionary<Type, PlayerState> _statesPool;

    [Inject]
    public PlayerStateCore(DiContainer diContainer)
    {
      _statesPool = new Dictionary<Type, PlayerState>()
      {
        [typeof(IdleState)] = diContainer.Instantiate<IdleState>(),
        [typeof(WalkState)] = diContainer.Instantiate<WalkState>(),
        [typeof(RunState)] = diContainer.Instantiate<RunState>(),
        [typeof(InactiveState)] = diContainer.Instantiate<InactiveState>()
      };
    }

    public void Init(GameEntity entity)
    {
      _state = _statesPool[typeof(IdleState)];
      _state.OnAdd(entity);
    }

    public void Set<T>(GameEntity entity)
      where T : PlayerState
    {
      _newState = _statesPool[typeof(T)];

      if (_newState == _state) return;

      _state.OnRemove(entity);
      _newState.OnAdd(entity);
      _state = _newState;
    }
  }

  public abstract class PlayerState
  {
    [Inject] protected readonly ILogger Logger;

    public abstract void OnAdd(GameEntity entity);
    public abstract void OnRemove(GameEntity entity);
  }
}