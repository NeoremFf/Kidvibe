using System.Collections.Generic;

namespace Kidvibe.GameLogic.Player.Effects.Core
{
  public interface IEffectPool
  {
    IReadOnlyCollection<EffectCore> Effects { get; }
    
    EffectCore GetBy<TEffectCore>() where TEffectCore : EffectCore;
  }
}