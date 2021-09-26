using System.Collections.Generic;
using Kidvibe.GameData.Static.Configs.Player;
using Kidvibe.GameLogic.Player.Effects.Core;
using Kidvibe.GameLogic.Player.State.Core;
using Kidvibe.GameLogic.Timer;
using Kidvibe.GameLogic.Timer.Pools;
using UnityEngine;
using Zenject;

namespace Kidvibe.ECS.Bootstrap.Player
{
  public class EcsPlayerEntity : MonoBehaviour
  {
    [Inject] private readonly PlayerStateCore _playerState;
    [Inject] private readonly PlayerMovementConfigs _moveConfigs;
    [Inject] private readonly PlayerDashConfigs _dashConfigs;
    [Inject(Id = "Player")] private readonly ITimerPool _timersPool;
    [Inject(Id = "Player")] private readonly IEffectPool _effectsPool;

    private void Awake()
    {
      var player = Contexts.sharedInstance.game.CreateEntity();
      var rb = gameObject.GetComponentInChildren<Rigidbody2D>();

      player.AddInput(Vector2.zero, false, false);
      player.AddState(_playerState);
      player.AddTimers(new List<TimerBody>(), _timersPool, player);
      player.AddEffects(new List<EffectCore>(), _effectsPool);
      player.AddRigidbody(rb);
      player.AddRunSpeed(_moveConfigs.RunSpeed, _moveConfigs.WalkSpeed);
      player.AddDashCharges(_dashConfigs.ChargeCount, _dashConfigs.ChargeCount);

      _playerState.Init(player);
    }
  }
}