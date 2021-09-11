using Entitas;
using UnityEngine;

namespace Kidvibe.ECS.Components.Player
{
  public class DashableComponent : IComponent { }

  public class DashComponent : IComponent
  {
    public float power;
    public Vector2 direction;
  }
}
