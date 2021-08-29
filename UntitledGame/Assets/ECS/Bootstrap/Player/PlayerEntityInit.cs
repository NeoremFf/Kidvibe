using System.Collections.Generic;
using Kidvibe.Assets.ECS.Components.Game.Timer;
using Kidvibe.Assets.ECS.Components.Game.Timer.Pools;
using Kidvibe.Assets.ECS.Components.Player.State;
using Kidvibe.Test;
using UnityEngine;
using Zenject;

namespace Kidvibe.Assets.ECS.Bootstrap.Player
{
  public class PlayerEntityInit : MonoBehaviour
  {
    [Inject] private readonly PlayerStateCore PlayerState;
    [Inject] private readonly PlayerTimerPool TimersPool;

    private void Start()
    {
      var player = Contexts.sharedInstance.game.CreateEntity();
      var rb = PlayerDataStorage.player.GetComponentInChildren<Rigidbody2D>();

      player.AddInput(Vector2.zero, false);
      player.AddState(PlayerState);
      player.AddTimers(new List<TimerBody>(), TimersPool, player);
      player.AddRigidbody(rb);
      
      PlayerState.Init(player);
    }
  }
}