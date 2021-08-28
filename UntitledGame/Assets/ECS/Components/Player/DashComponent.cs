using Entitas;

namespace Kidvibe.Assets.ECS.Components.Player.Dash
{
  public class DashableComponent : IComponent { }

  public class DashComponent : IComponent
  {
    public float power;
    public float duration;
  }
}
