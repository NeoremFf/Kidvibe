using Kidvibe.Assets.Utils;
using Zenject;

namespace Kidvibe.ECS.Components.Player.State.Core
{
  public abstract class PlayerState
  {
    [Inject] protected readonly ILogger logger;

    protected GameEntity entity;

    public void Init(GameEntity entity)
    {
      this.entity = entity;
    }

    public abstract void OnAdd();
    public abstract void OnRemove();

    public virtual void OnAdd(object data) { }
  }
}