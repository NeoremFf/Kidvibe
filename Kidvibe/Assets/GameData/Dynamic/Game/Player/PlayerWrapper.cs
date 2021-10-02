using Kidvibe.GameData.Dynamic.Game.Player.MainGame;
using Zenject;

namespace Kidvibe.GameData.Dynamic.Game.Player
{
  public class PlayerWrapper
  {
    public readonly PlayerDashWrapper dashData;

    [Inject]
    public PlayerWrapper(DiContainer di)
    {
      dashData = di.Instantiate<PlayerDashWrapper>();
    }
  }
}