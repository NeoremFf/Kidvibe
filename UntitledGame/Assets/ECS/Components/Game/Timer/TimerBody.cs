using System.Collections.Generic;
using Kidvibe.Assets.Utils;
using Zenject;

namespace Kidvibe.Assets.ECS.Components.Game.Timer
{
  public abstract class TimerBody
  {
    [Inject] protected readonly ILogger Logger;

    private bool _isRun;  
    protected float time;

    protected GameEntity entity;

    public TimerBody(GameEntity entity)
    {
      this.entity = entity; 
    }

    public abstract void Run();

    public virtual void Run(float startTime)
    {
      Logger.Log($"Timer is run in {startTime} seconds!");

      time = startTime;
      _isRun = true;
    }

    public void Tick(float timeLeft)
    {
      if (!_isRun) return;

      time -= timeLeft;

      if (time <= 0)
        OnExpired();
    }

    protected virtual void OnExpired()
    {
      _isRun = false;
    }
  }
}