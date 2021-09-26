using System;
using System.Collections.Generic;
using Kidvibe.GameLogic.Player.Effects.Core;
using Kidvibe.GameLogic.Player.Effects.Entities.Player;
using Zenject;

namespace Kidvibe.GameLogic.Player.Effects.Pools
{
  public class PlayerEffectsPool : IEffectPool
  {
    public IReadOnlyCollection<EffectCore> Effects => Pool.Values;
    
    private Dictionary<Type, EffectCore> Pool { get; }
    
    [Inject]
    public PlayerEffectsPool(DiContainer di)
    {
      Pool = new Dictionary<Type, EffectCore>()
      {
        [typeof(WeaknessEffect)] = di.Instantiate<WeaknessEffect>(),
      };
    }
    
    public EffectCore GetBy<TEffectCore>() where TEffectCore : EffectCore
    {
      var body = Pool[typeof(TEffectCore)];

      if (body == null)
        throw new ArgumentException($"Pool {nameof(PlayerEffectsPool)} does not contained Body {nameof(TEffectCore)}");
      
      return body;
    }
  }
}