using Entitas;

namespace Kidvibe.ECS.Systems.Player
{
  public class EffectsSystem : IInitializeSystem
  {
    private readonly IGroup<GameEntity> _effects;

    public EffectsSystem(GameContext context)
    {
      _effects = context.GetGroup(GameMatcher.Timers);
    }
    
    public void Initialize()
    {
      foreach (var entity in _effects)
        entity.effects.Init(entity);
    }
  }
}