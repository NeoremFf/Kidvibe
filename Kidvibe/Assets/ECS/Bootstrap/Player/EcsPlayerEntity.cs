using System.Collections.Generic;
using Kidvibe.Game.Timer.Pools;
using Kidvibe.GameData.Static.Configs.Player;
using Kidvibe.GameLogic.Player.State.Core;
using Kidvibe.GameLogic.Timer;
using UnityEngine;
using Zenject;

namespace Kidvibe.ECS.Bootstrap.Player
{
  public class EcsPlayerEntity : MonoBehaviour
  {
    [Inject] private readonly PlayerStateCore _playerState;
    [Inject] private readonly PlayerDashConfigs _dashConfigs;
    [Inject(Id = "Player")] private readonly ITimerPool _timersPool;

    private void Awake()
    {
      var player = Contexts.sharedInstance.game.CreateEntity();
      var rb = gameObject.GetComponentInChildren<Rigidbody2D>();

      player.AddInput(Vector2.zero, false, false);
      player.AddState(_playerState);
      player.AddTimers(new List<TimerBody>(), _timersPool, player);
      player.AddRigidbody(rb);
      player.AddDashCharges(_dashConfigs.ChargeCount, _dashConfigs.ChargeCount);

      _playerState.Init(player);
    }
  }
}