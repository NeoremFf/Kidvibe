using System;
using System.Collections.Generic;
using Kidvibe.Assets.Utils;
using Zenject;

namespace Kidvibe.Assets.ECS.Components.Player.State
{
  public interface IPlayerStateCore
  {
    void Set<T>(GameEntity entity) where T : PlayersState, new();
  }

  public class PlayerStateCore : IPlayerStateCore
  {
    private PlayersState _state;
    private PlayersState _newState;

    private Dictionary<Type, PlayersState> _statesPool;

    [Inject]
    public PlayerStateCore(DiContainer diContainer)
    {
      _statesPool = new Dictionary<Type, PlayersState>()
      {
        [typeof(IdleState)] = diContainer.Instantiate<IdleState>(),
        [typeof(MoveState)] = diContainer.Instantiate<MoveState>(),
        [typeof(RunState)] = diContainer.Instantiate<RunState>(),
        [typeof(InactiveState)] = diContainer.Instantiate<InactiveState>(),
      };

      _state = _statesPool[typeof(IdleState)];
    }

    public void Set<T>(GameEntity entity)
      where T : PlayersState, new()
    {
      _newState = _statesPool[typeof(T)];

      _state.OnRemove(entity);
      _newState.OnAdd(entity);
      _state = _newState;
    }
  }

  public abstract class PlayersState
  {
    [Inject] protected readonly ILogger logger;

    public abstract void OnAdd(GameEntity entity);
    public abstract void OnRemove(GameEntity entity);
  }

  public class IdleState : PlayersState
  {
    public override void OnAdd(GameEntity entity)
    {
      logger.Log("Create " + nameof(IdleState));
    }

    public override void OnRemove(GameEntity entity)
    {
      logger.Log("Remove " + nameof(IdleState));
    }
  }

  public class MoveState : PlayersState
  {
    public override void OnAdd(GameEntity entity)
    {
      logger.Log("Create " + nameof(MoveState));
    }

    public override void OnRemove(GameEntity entity)
    {
      logger.Log("Remove " + nameof(MoveState));
    }
  }

  public class RunState : PlayersState
  {
    public override void OnAdd(GameEntity entity)
    {
      logger.Log("Create " + nameof(RunState));
    }

    public override void OnRemove(GameEntity entity)
    {
      logger.Log("Remove " + nameof(RunState));
    }
  }

  public class DashState : PlayersState
  {
    public override void OnAdd(GameEntity entity)
    {
      logger.Log("Create " + nameof(DashState));
      // entity.AddDash(); TODO
    }

    public override void OnRemove(GameEntity entity)
    {
      logger.Log("Remove " + nameof(DashState));
      entity.RemoveDash();
    }
  }

  public class InactiveState : PlayersState
  {
    public override void OnAdd(GameEntity entity)
    {
      logger.Log("Create " + nameof(InactiveState));
    }

    public override void OnRemove(GameEntity entity)
    {
      logger.Log("Remove " + nameof(InactiveState));
    }
  }
}
