using System;
using System.Collections.Generic;

namespace Kidvibe.Assets.ECS.Components.Game.Timer.Pools
{
  public class PlayerTimerPool : TimerPool
  {
    public PlayerTimerPool(Dictionary<Type, TimerBody> pool) : base(pool)
    { }
  }
}