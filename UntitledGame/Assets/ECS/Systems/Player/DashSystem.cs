using Entitas;
using Kidvibe.Assets.ECS.Components.Game;
using Kidvibe.Assets.GameData.Static.Configs.Player;
using UnityEngine;
using Zenject;

namespace Kidvibe.Assets.ECS.Systems.Player
{
  public class DashSystem : IExecuteSystem
  {
    public int Age { get; set; }

    private readonly IGroup<GameEntity> Dashes;

    public DashSystem(GameContext context)
    {
      Dashes = context.GetGroup(
        GameMatcher.AllOf(GameMatcher.Rigidbody,
          GameMatcher.Dash,
          GameMatcher.Timers));
    }

    public void Execute()
    {
      foreach (var entity in Dashes)
      {
        // entity.rigidbody.rigidbody.velocity = entity.input.direction
        entity.timers.Add(new TimerBodyDashDuration() );

        Debug.Log($"Dash is run!");
      }
    }
  }

  public class DashableSystem : IExecuteSystem
  {
    private readonly IGroup<GameEntity> Dashable;

    [Inject] private readonly PlayerMovementConfigs Configs;

    public DashableSystem(GameContext context)
    {
      Dashable = context.GetGroup(
        GameMatcher.AllOf(GameMatcher.Input,
            GameMatcher.Dashable));
    }

    public void Execute()
    {
      foreach (var entity in Dashable)
      {
        if (entity.input.dash
            && entity.isDashable
            && !entity.hasDash)
        {
          entity.AddDash(Configs.DashConfigs.Power, Configs.DashConfigs.Duration);

          Debug.Log("Set Dash");
        }
      }
    }
  }
}
