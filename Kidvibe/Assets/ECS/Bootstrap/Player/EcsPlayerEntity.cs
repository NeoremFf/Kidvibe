using System.Collections.Generic;
using Kidvibe.ECS.Components.Game.Timer;
using Kidvibe.ECS.Components.Game.Timer.Pools;
using Kidvibe.ECS.Components.Player.State.Core;
using UnityEngine;
using Zenject;

namespace Kidvibe.ECS.Bootstrap.Player
{
  public class EcsPlayerEntity : MonoBehaviour
  {
    [Inject] private readonly PlayerStateCore _playerState;
    [Inject(Id = "Player")] private readonly ITimerPool _timersPool;

    private void Awake()
    {
      var player = Contexts.sharedInstance.game.CreateEntity();
      var rb = gameObject.GetComponentInChildren<Rigidbody2D>();

      player.AddInput(Vector2.zero, false);
      player.AddState(_playerState);
      player.AddTimers(new List<TimerBody>(), _timersPool, player);
      player.AddRigidbody(rb);
      
      _playerState.Init(player);
    }
  }
}