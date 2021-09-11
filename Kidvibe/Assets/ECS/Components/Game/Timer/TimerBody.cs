using Kidvibe.Assets.Utils;
using Zenject;

namespace Kidvibe.ECS.Components.Game.Timer
{
  public abstract class TimerBody
  {
    [Inject] protected readonly ILogger logger;

    private bool _isPause;

    private bool _isRun;
    private float _time;

    protected GameEntity entity;

    public TimerBody Init(GameEntity entity)
    {
      this.entity = entity;
      return this;
    }

    public abstract void Run();

    public void Run(float startTime)
    {
      logger.Log($"Timer is run in {startTime} seconds!");

      _time = startTime;
      _isRun = true;
      _isPause = false;
    }

    public void Continue() => _isPause = false;
    public void Pause() => _isPause = true;

    public void Tick(float timeLeft)
    {
      if (!_isRun || _isPause) return;

      _time -= timeLeft;

      if (_time <= 0)
        OnExpired();
    }

    protected virtual void OnExpired()
    {
      _isRun = false;
    }
  }
}