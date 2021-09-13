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

  public class DashChargesComponent : IComponent
  {
    public int count;
    public int maxCount;

    public void Reset() =>
      count = maxCount;

    public void Add(int add = 1) =>
      count += add;
    
    public void Remove(int remove = 1) =>
      count -= remove;
    
    public void Set(int newCount) =>
      count = newCount;
  }
}
