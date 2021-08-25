using Entitas;
using Kidvibe.Assets.ECS.Components.Tools;

namespace Kidvibe.Assets.ECS.Components.Player.Dash
{
  public class DashComponent : IComponent
  {
    public float power;
    public float duration;
  }

  public class DashableComponent : IComponent
  {
  }

  public class CdDashComponent : CdComponent
  {
  }
}
