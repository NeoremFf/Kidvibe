using System;

namespace Kidvibe.GameData.Static.Configs.Player
{
  [Serializable]
  public class PlayerMovementConfigs
  {
    public float WalkSpeed { get; set; } = 5;
    public float RunSpeed { get; set; } = 5;
  }

  [Serializable]
  public class PlayerDashConfigs
  {
    public float Power { get; set; } = 15;
    public float Duration { get; set; } = 0.36f;
  }
}
