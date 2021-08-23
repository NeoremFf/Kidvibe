using UnityEngine;

namespace Kidvibe.Assets.ECS.Components.Player
{
  public struct DashableComponent
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