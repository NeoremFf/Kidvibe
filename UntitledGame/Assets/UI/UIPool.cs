using System;
using System.Collections.Generic;
using UnityEngine;

namespace UI
{
  public enum UIKey
  {
    None = 0,

    MainMenu = 1,
    Lobby = 2,
  }

  public static class UIPool
  {
    private static Dictionary<UIKey, UIItem> uiItems;

    private const string PrefabsPath = @"Path\"; 

    static UIPool()
    {
      uiItems = new Dictionary<UIKey, UIItem>();

      Create();

      Validate();
    }

    public static UIItem Get(UIKey key) => uiItems[key];

    private static void Create()
    {
      uiItems.Add(
        UIKey.MainMenu,
        new UIItem(UIKey.MainMenu,
          Resources.Load<GameObject>("Prefabs\\MainMenu"),
          new UIConfiguration() { Hide = HideParametr.Common, Show = ShowParametr.ForcedHideAll, CacheType = CacheParametr.Cached }
          ));

      uiItems.Add(
        UIKey.Lobby,
        new UIItem(UIKey.Lobby,
          Resources.Load<GameObject>("Prefabs\\Lobby"),
          new UIConfiguration() { Hide = HideParametr.Common, Show = ShowParametr.ForcedHideAll, CacheType = CacheParametr.Cached }
          ));
    }

    private static void Validate()
    {
      foreach (var item in uiItems)
      {
        if (item.Key != item.Value.key)
          throw new Exception("Keys must be the same");
      }
    }
  }
}