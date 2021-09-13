namespace Kidvibe.GameLogic.Timer
{
  public abstract class DelayTimerBody : TimerBody
  {
    protected bool isDelay = true;
    
    public abstract void RunDelay();

    protected void RunDelay(float delayTime)
    {
      logger.Log("<color=blue>[TIMER]</color> is running with delay");

      isDelay = true;
      Run(delayTime);
    }

    protected override void OnExpired()
    {
      logger.Log("<color=blue>[TIMER]</color> delay has been expired. Start timer ticking");

      if (!isDelay)
      {
        base.OnExpired();
        
        return;
      }
      
      Run();
    }
  }
}