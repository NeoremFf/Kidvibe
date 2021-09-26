using System.Collections.Generic;
using Entitas;
using Kidvibe.GameLogic.Player.Effects.Core;

namespace Kidvibe.ECS.Components.Player
{
  public class EffectsComponent : IComponent
  {
    public List<EffectCore> effects;
    public IEffectPool pool;

    
    public void Init(GameEntity entity)
    {
      effects = new List<EffectCore>();
      foreach (var effect in pool.Effects)
        effects.Add(effect.Init(entity));
    }

    public bool Has<TEffectType>()
      where TEffectType : EffectCore, new() =>
      Get<TEffectType>().State;
    
    public void Apply<TEffectType>()
      where TEffectType : EffectCore, new() =>
      Get<TEffectType>().Apply();
    
    public void Disable<TEffectType>()
      where TEffectType : EffectCore, new() =>
      Get<TEffectType>().Disable();

    private EffectCore Get<TEffectType>()
      where TEffectType : EffectCore, new() =>
      pool.GetBy<TEffectType>();
  }
}