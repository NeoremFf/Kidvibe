
using UnityEngine;

namespace Kidvibe.Assets.ECS.Components.Player.State
{
  public class IdleState : PlayerState
  {
    public override void OnAdd(GameEntity entity)
    {
      entity.isMovable = true;

      Debug.Log("Add movable");
    }

    public override void OnRemove(GameEntity entity) { }
  }
}
