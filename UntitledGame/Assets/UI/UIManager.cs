using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace UI
{
  public static class UIManager
  {
    private static UIRootManager root;

    private static bool _rootWasFunded = false;

    private static readonly List<UIElement> ActiveUiElements;
    private static readonly List<UIElement> Cache;

    static UIManager()
    {
      ActiveUiElements = new List<UIElement>();
      Cache = new List<UIElement>();

      FindRoot();
    }

    public static void Show(UIKey key, UITarget target = null)
    {
      foreach (var item in Cache.Where(item => item.Key == key))
      {
        if (item.HideOther)
          HideOther(item.ForcedHideOther);

        item.Show();

        return;
      }

      ShowNew(key, target);
    }

    public static void ShowNew(UIKey key, UITarget target = null,
      UIConfiguration configs = null)
    {
      if (!_rootWasFunded)
        FindRoot();

      var item = UIPool.Get(key);

      var go = GameObject.Instantiate(item.prefab, root.Canvas.transform);

      var uiElement = go.GetComponent<UIElement>();

      uiElement.Init(key, configs ?? item.configuration);

      if (uiElement.HideOther)
        HideOther(uiElement.ForcedHideOther);

      ActiveUiElements.Add(uiElement);
      Cache.Add(uiElement);

      uiElement.Show();
    }

    private static void HideOther(bool force)
    {
      foreach (var element in ActiveUiElements)
      {
        if (element.NeverHide)
          if (!force)
            continue;

        if (element.NeedRemoveFromCache)
          Cache.Remove(element);

        element.Hide();
      }
    }

    private static void FindRoot()
    {
      root = Object.FindObjectOfType<UIRootManager>();

      if (root == null)
        throw new System.NullReferenceException("Can not to find root for ui (UIRootManager).");

      _rootWasFunded = true;
    }
  }
}