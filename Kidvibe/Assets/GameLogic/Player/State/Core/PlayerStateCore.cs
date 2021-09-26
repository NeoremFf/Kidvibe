using System;
using System.Collections.Generic;
using Zenject;

namespace Kidvibe.GameLogic.Player.State.Core
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
        [typeof(RunState)] = diContainer.Instantiate<RunState>(),
        [typeof(DashState)] = diContainer.Instantiate<DashState>(),
        [typeof(InactiveState)] = diContainer.Instantiate<InactiveState>()
      };
    }

    public void Init(GameEntity entity)
    {
      foreach (var state in _statesPool)
      {
        state.Value.Init(entity);
      }

      _state = _statesPool[typeof(IdleState)];

      _state.OnAdd();
    }

    public void Set<TState>()
      where TState : PlayerState
    {
      _newState = GetNewState<TState>();

      if (_newState == _state) return;

      _state.OnRemove();
      _newState.OnAdd();
      _state = _newState;
    }

    public void Set<TState>(object data)
      where TState : PlayerState
    {
      _newState = GetNewState<TState>();
      
      if (_newState == _state) return;

      _state.OnRemove();
      _newState.OnAdd(data);
      _state = _newState;
    }

    private PlayerState GetNewState<TState>() =>
      _statesPool[typeof(TState)];
  }
}