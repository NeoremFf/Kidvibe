using Kidvibe.GameData.Static.Configs.Player;
using Zenject;

namespace Kidvibe.GameData.Dynamic.Game.Player.MainGame
{
  public class PlayerDashWrapper
  {
    private PlayerDashConfigs _dashConfigs;

    public int MaxCount { get; }
    public int Count { get; private set; }

    public float Power { get; }
    
    [Inject] 
    public PlayerDashWrapper(PlayerDashConfigs dashConfigs)
    {
      _dashConfigs = dashConfigs;
      
      MaxCount = _dashConfigs.ChargeCount;
      Count = _dashConfigs.ChargeCount;

      Power = _dashConfigs.Power;
    }
    
    public void Add(int add = 1) =>
      Count += add;
    
    public void Remove(int remove = 1) =>
      Count -= remove;
  }
}