using Kidvibe.Utils;
using Zenject;

namespace Kidvibe.GameLogic.Player.Effects.Core
{
  public class EffectCore
  {
    [Inject] protected ILogger logger;
    
    public bool State { get; private set; }

    protected GameEntity entity;

    public EffectCore Init(GameEntity entity)
    {
      this.entity = entity;
      return this;
    }
    
    public void Apply()
    {
      State = true;

      Applied();
    }

    public void Disable()
    {
      State = false;

      Disabled();
    }

    protected virtual void Applied() { }
    protected virtual void Disabled() { }
  }
}