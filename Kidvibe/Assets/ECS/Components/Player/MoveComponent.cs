using Entitas;

namespace Kidvibe.ECS.Components.Player
{
  public class MovableComponent : IComponent { }

  public class WalkComponent : IComponent { public float speed; }

  public class RunComponent : IComponent { public float speed; }
}
