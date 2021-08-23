using Entitas;
using UnityEngine;

namespace Kidvibe.Assets.ECS.Components
{
  public class InputComponent : IComponent
  {
    public Vector2 direction;
    public bool dash;
  }
}