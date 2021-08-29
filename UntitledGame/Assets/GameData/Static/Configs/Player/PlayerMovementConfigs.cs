using System;

namespace Kidvibe.Assets.GameData.Static.Configs.Player
{
  [Serializable]
  public class PlayerMovementConfigs
  {
    public float WalkSpeed { get; set; } = 20;
    public float RunSpeed { get; set; } = 40;
  }

  [Serializable]
  public class PlayerDashConfigs
  {
    public float Power { get; set; } = 13000;
    public float Duration { get; set; } = 2;
  }
}
