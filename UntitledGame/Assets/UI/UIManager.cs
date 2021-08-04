using System.Collections.Generic;
using UnityEngine;

namespace UI
{
  public static class UIManager
  {
    public static IReadOnlyCollection<UIElement> UIElements => _activeUIElements.AsReadOnly();
    public static Transform RootTransform => _root?.gameObject.transform ??
      FindRoot().gameObject.transform;

    private static UIRootManager _root;

    private static bool _rootWasFined = false;

    private static List<UIElement> _activeUIElements;
    private static List<UIElement> _cache;

    static UIManager()
    {
      _activeUIElements = new List<UIElement>();
      _cache = new List<UIElement>();

      FindRoot();
    }

    static public void Show(UIElement uiElement)
    {
      if (_cache.Contains(uiElement))
        uiElement.Show();
      else
        ShowNew(uiElement, uiElement.Element);
    }

    static public void ShowNew(UIElement uiElement, GameObject uiObject,
      UIConfiguration configs = null)
    {
      if (!_rootWasFined)
        FindRoot();

      if (configs != null)
        uiElement.Init(configs);  

      _activeUIElements.Add(uiObject.GetComponent<UIElement>());
      _cache.Add(uiElement);

      uiElement.Show();
    }

    static private void HideOther()
    {
      if (true)
      {
        foreach (var element in _activeUIElements)
        {
          if (element.NeverHide)
            if (true)
              continue;

          MonoBehaviour.Destroy(element.gameObject);

          element.Hide();
        }
      }
    }

    static private UIRootManager FindRoot()
    {
      _root = MonoBehaviour.FindObjectOfType<UIRootManager>();

      if (_root == null)
        throw new System.NullReferenceException("Can not to find root for ui (UIRootManager).");

      _rootWasFined = true;

      return _root;
    }
  }
}