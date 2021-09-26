using Kidvibe.Utils;
using Zenject;
using ILogger = Kidvibe.Utils.ILogger;

namespace Kidvibe.GameLogic.Timer
{
  public abstract class TimerBody
  {
    [Inject] protected readonly ILogger logger;

    private bool _isRun;
    private bool _isDelay;

    private float _time;
    private float _delay;

    protected GameEntity entity;

    public TimerBody Init(GameEntity entity)
    {
      this.entity = entity;
      
      return this;
    }

    public abstract void Run();

    public virtual void Delay() { }

    public void Tick(float timeLeft)
    {
      if (_isDelay)
        DelayTick(timeLeft);
      else if (_isRun)
        TimeTick(timeLeft);
    }
    
    protected void Run(float startTime)
    {
      logger.LogWithTag(LogTag.Timer, LogColor.Orange, $"is running in {startTime} seconds");
      
      _time = startTime;
      _delay = 0;
      
      _isRun = true;
      _isDelay = false;
    }
    
    protected void Delay(float delayTime)
    {
      logger.LogWithTag(LogTag.Timer, LogColor.Orange, $"is delay in {delayTime} seconds");
      
      _delay = delayTime;
      _isDelay = true;
    }

    protected virtual void Expired()
    {
      _isRun = false;
    }
    
    private void TimeTick(float timeLeft)
    {
      _time -= timeLeft;

      if (_time <= 0) 
        Expired();
    }
    
    private void DelayTick(float timeLeft)
    {
      _delay -= timeLeft;

      if (_delay <= 0)
        DelayEnded();
    }
    
    private void DelayEnded()
    {
      logger.LogWithTag(LogTag.Timer, LogColor.Orange, "delay has been expired");
      
      _isDelay = false;

      if (_isRun)
      {
        logger.LogWithTag(LogTag.Timer, LogColor.Orange, "continue run.");
      }
      else
      {
        Run();

        logger.LogWithTag(LogTag.Timer, LogColor.Orange, "start run after delay.");
      }
    }
  }
}