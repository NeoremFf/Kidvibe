using System;

namespace Kidvibe.Assets.GameData.Static.Configs.Player
{
  [Serializable]
  public class PlayerMovementConfigs
  {
    public float MoveSpeed { get; set; } = 20;
    public float RunSpeed { get; set; } = 40;
    public float DashPower { get; set; } = 13000;
  }
}
