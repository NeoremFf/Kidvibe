using System;
using Entitas;

namespace Kidvibe.ECS.Components.Player
{
  public class MovableComponent : IComponent { }
  
  public class RunComponent : IComponent { }
  
  public class RunSpeedComponent : IComponent
  {
    public float run;
    public float walk;

    public void ChangeRunSpeed(float newSpeed)
    {
      if (newSpeed >= 0)
      {
        run = newSpeed;
      }
    }
  }
}
