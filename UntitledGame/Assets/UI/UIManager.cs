using System.Collections.Generic;
using UnityEngine;

namespace UI
{
  public static class UIManager
  {
    private static UIRootManager _root;

    private static bool _rootWasFinded = false;

    private static List<UIElement> _activeUIElements;
    private static List<UIElement> _cache;

    static UIManager()
    {
      _activeUIElements = new List<UIElement>();
      _cache = new List<UIElement>();

      FindRoot();
    }

    public static void Show(UIKey key, UITarget target = null)
    {
      foreach (var item in _cache)
      {
        if (item.Key == key)
        {
          if (item.HideOther)
            HideOther(item.ForcedHideOther);

          item.Show();

          return;
        }
      }

      ShowNew(key, target);
    }

    public static void ShowNew(UIKey key, UITarget target = null,
      UIConfiguration configs = null)
    {
      if (!_rootWasFinded)
        FindRoot();

      var item = UIPool.Get(key);

      var go = GameObject.Instantiate(item.prefab, _root.Canvas.transform);

      var uiElement = go.GetComponent<UIElement>();

      uiElement.Init(key, configs ?? item.configuration);

      if (uiElement.HideOther)
        HideOther(uiElement.ForcedHideOther);

      _activeUIElements.Add(uiElement);
      _cache.Add(uiElement);

      uiElement.Show();
    }

    static private void HideOther(bool force)
    {
      if (true)
      {
        foreach (var element in _activeUIElements)
        {
          if (element.NeverHide)
            if (!force)
              continue;

          if (element.NeedRemoveFromCache)
            _cache.Remove(element);

          element.Hide();
        }
      }
    }

    static private UIRootManager FindRoot()
    {
      _root = MonoBehaviour.FindObjectOfType<UIRootManager>();

      if (_root == null)
        throw new System.NullReferenceException("Can not to find root for ui (UIRootManager).");

      _rootWasFinded = true;

      return _root;
    }
  }
}