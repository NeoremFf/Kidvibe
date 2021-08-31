using System.Collections.Generic;
using Kidvibe.Assets.ECS.Components.Game.Timer;
using Kidvibe.Assets.ECS.Components.Game.Timer.Pools;
using Kidvibe.Assets.ECS.Components.Player.State;
using UnityEngine;
using Zenject;

namespace Kidvibe.Assets.ECS.Bootstrap.Player
{
  public class EcsPlayerEntity : MonoBehaviour
  {
    [Inject] private readonly PlayerStateCore PlayerState;
    [Inject(Id = "Player")] private readonly ITimerPool TimersPool;

    private void Awake()
    {
      var player = Contexts.sharedInstance.game.CreateEntity();
      var rb = gameObject.GetComponentInChildren<Rigidbody2D>();

      player.AddInput(Vector2.zero, false);
      player.AddState(PlayerState);
      player.AddTimers(new List<TimerBody>(), TimersPool, player);
      player.AddRigidbody(rb);
      
      PlayerState.Init(player);
    }
  }
}