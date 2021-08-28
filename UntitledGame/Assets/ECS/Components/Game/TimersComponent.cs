using System.Collections.Generic;
using Entitas;
using UnityEngine;

namespace Kidvibe.Assets.ECS.Components.Game
{
  public class TimersComponent : IComponent
  {
    public List<TimerBody> bodies;

    public void Add(TimerBody newTimer)
    {
      bodies.Add(newTimer);
    }
  }

  public abstract class TimerBody
  {
    public bool IsActive { get; private set; }

    protected GameEntity entity;

    private float _time;

    protected TimerBody(float startTime, GameEntity entity)
    {
      this.entity = entity;

      Debug.Log($"Timer set with {startTime} seconds!");
      _time = startTime;
    }

    public virtual void Run(float startTime)
    {
      Debug.Log($"Timer is run in {startTime} seconds!");

      _time = startTime;
      IsActive = true;
    }

    public void Tick(float timeLeft)
    {
      if (!IsActive)
        return;

      _time -= timeLeft;

      if (_time <= 0)
        OnTimeLeft();
    }

    protected virtual void OnTimeLeft()
    {
      IsActive = false;
    }
  }

  public class TimerBodyDashDuration : TimerBody
  {
    public TimerBodyDashDuration(float startTime, GameEntity entity)
      : base(startTime, entity)
    { }

    protected override void OnTimeLeft()
    {
      base.OnTimeLeft();

      Debug.Log("Dash has been done!");

      entity.isDashable = true;
      entity.RemoveDash();
    }
  }
}
