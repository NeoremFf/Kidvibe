using Kidvibe.Assets.ECS.Components.Player.State;
using Kidvibe.Test;
using UnityEngine;
using Zenject;

namespace Kidvibe.Assets.ECS.Bootstrap.Player
{
  public class PlayerEntityInit : MonoBehaviour
  {
    [Inject] private PlayerStateCore _PlayerState;

    private void Start()
    {
      var player = Contexts.sharedInstance.game.CreateEntity();
      var rb = PlayerDataStorage.player.GetComponentInChildren<Rigidbody2D>();

      player.AddState(_PlayerState);
      player.AddRigidbody(rb);
      player.AddInput(Vector2.zero, false);
      player.AddCdDash(10);
    }
  }
}