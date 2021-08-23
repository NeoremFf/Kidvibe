using Kidvibe.Assets.ECS.Components;
using Kidvibe.Assets.ECS.Components.Player;
using Kidvibe.Test;
using Leopotam.Ecs;
using UnityEngine;

namespace Kidvibe.Assets.ECS.MainGame
{
  public class MainGameInitialSystem : IEcsInitSystem
  {
    private EcsWorld _world = null;

    public void Init()
    {
      var player = _world.NewEntity();
      ref var playerMove = ref player.Get<MovableComponent>();
      ref var playerInput = ref player.Get<InputComponent>();
      ref var playerDash = ref player.Get<DashableComponent>();

      playerMove.rigidbody = PlayerDataStorage.player.GetComponentInChildren<Rigidbody2D>();
      playerMove.speed = PlayerDataStorage.speed;

      playerDash.rigidbody = PlayerDataStorage.player.GetComponentInChildren<Rigidbody2D>();
      playerDash.duration = 2;
      playerDash.can = true;
    }
  }
}