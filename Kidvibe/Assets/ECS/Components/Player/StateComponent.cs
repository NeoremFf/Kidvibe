using Entitas;
using Kidvibe.GameLogic.Player.State.Core;

namespace Kidvibe.ECS.Components.Player
{
  public class StateComponent : IComponent
  {
    public PlayerStateCore currentState;
  }
}
