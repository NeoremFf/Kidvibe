using Kidvibe.Utils;

namespace Kidvibe.GameLogic.Timer
{
  public abstract class DelayTimerBody : TimerBody
  {
    protected bool isDelay = true;
    
    public abstract void RunDelay();

    protected void RunDelay(float delayTime)
    {
      logger.LogWithTag(LogTag.Timer, LogColor.Orange, "is running with delay");

      isDelay = true;
      Run(delayTime);
    }

    protected override void Expired()
    {
      logger.LogWithTag(LogTag.Timer, LogColor.Orange, "delay has been expired. Start timer ticking");

      if (!isDelay)
      {
        base.Expired();
        
        return;
      }
      
      Run();
    }
  }
}