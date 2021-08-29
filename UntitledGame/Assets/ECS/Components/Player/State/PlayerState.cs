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

    public void Set<T>()
      where T : PlayerState
    {
      _newState = _statesPool[typeof(T)];

      if (_newState == _state) return;

      _state.OnRemove();
      _newState.OnAdd();
      _state = _newState;
    }
  }

  public abstract class PlayerState
  {
    [Inject] protected readonly ILogger Logger;

    protected GameEntity entity;

    public void Init(GameEntity entity)
    {
      this.entity = entity;
    }

    public abstract void OnAdd();
    public abstract void OnRemove();
  }
}