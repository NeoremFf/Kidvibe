using Entitas;
using UnityEngine;
using Zenject;

namespace Kidvibe.Assets.ECS.Systems.Tools
{
  public class CdSystem : IExecuteSystem
  {
    [Inject]  private readonly Utils.ILogger Logger;

    private readonly IGroup<GameEntity> CdGroup;

    [Inject]
    public CdSystem(GameContext context)
    {
      CdGroup = context.GetGroup(GameMatcher.CdDash);
    }

    public void Execute()
    {
      foreach (var entity in CdGroup)
      {
        entity.cdDash.timer -= Time.deltaTime;
        Logger.Log(entity.cdDash.timer.ToString());

        if (entity.cdDash.timer <= 0)
          entity.RemoveCd();
      }
    }
  }
}
