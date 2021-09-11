using Entitas;
using UnityEngine;

namespace Kidvibe.ECS.Components.Player
{
  public class InputComponent : IComponent
  {
    public Vector2 direction;
    public bool dash;
  }
}