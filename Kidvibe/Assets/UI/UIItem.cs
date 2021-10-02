using UnityEngine;

namespace Kidvibe.UI
{
  public class UIItem
  {
    public readonly UIKey key;
    public readonly GameObject prefab;
    public readonly UIConfiguration configuration;

    public UIItem(UIKey uiKey, GameObject template, UIConfiguration config)
    {
      key = uiKey;
      prefab = template;
      configuration = config;
    }
  }
}
