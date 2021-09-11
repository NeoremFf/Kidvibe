using Entitas;
using Kidvibe.ECS.Components.Player.State.Core;

namespace Kidvibe.ECS.Components.Player.State
{
  public class StateComponent : IComponent
  {
    public PlayerStateCore currentState;
  }
}
