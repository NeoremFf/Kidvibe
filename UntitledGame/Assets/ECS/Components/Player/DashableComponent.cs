using Entitas;
using UnityEngine;

namespace Kidvibe.Assets.ECS.Components.Player
{
  public class DashableComponent : IComponent
  {
    public Rigidbody2D rigidbody;
    public int power;
    public float duration;
    public float cd;
    public bool run;
  }

  public struct CdComponent<T>
  {
    public float timer;

    public CdComponent(int a)
    {
      timer = 0;
    }
  }
}