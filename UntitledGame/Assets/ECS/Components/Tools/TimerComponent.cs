using Entitas;

namespace Kidvibe.Assets.ECS.Components.Tools
{
  public class TimerComponent : IComponent
  {
    public float timeLeft;
    public bool isRun;
    public bool isFinished;
  }
}
