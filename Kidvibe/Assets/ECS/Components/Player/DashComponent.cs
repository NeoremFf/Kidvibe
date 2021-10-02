using Entitas;
using Kidvibe.GameData.Dynamic.Game.Player;
using UnityEngine;
using Zenject;

namespace Kidvibe.ECS.Components.Player
{
  public class DashableComponent : IComponent { }

  public class DashComponent : IComponent
  {
    public float power;
    public Vector2 direction;
  }

  public class DashChargesComponent : IComponent
  {
    public int count;
  }
}
