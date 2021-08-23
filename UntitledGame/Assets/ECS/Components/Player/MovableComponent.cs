using Entitas;
using UnityEngine;

public class MovableComponent : IComponent
{
  public Rigidbody2D rigidbody;
  public float speed;
}
