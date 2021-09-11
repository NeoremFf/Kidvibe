using UnityEngine;
using UI;

public class UIElement : MonoBehaviour
{
  public UIKey Key { get; private set; }

  public GameObject Element =>
    _element;

  public bool HideOther => _config.Show == ShowParametr.HideAll || ForcedHideOther;
  public bool ForcedHideOther => _config.Show == ShowParametr.ForcedHideAll;

  public bool NeedRemoveFromCache => _config.CacheType == CacheParametr.Destroy;

  public bool NeverHide => _config.Hide == HideParametr.NeverHide;

  private GameObject _element;

  private UIConfiguration _config;

  private void Awake()
  {
    Create();
  }

  protected virtual void Create()
  {
    _element = gameObject;

    _element.SetActive(false);
  }

  public virtual void Init(UIKey key, UIConfiguration configs)
  {
    Key = key;

    _config = configs ?? new UIConfiguration();

    if (_config.CacheType == CacheParametr.Cached)
      DontDestroyOnLoad(gameObject);
  }

  public virtual void Show()
  {
    _element.SetActive(true);
  }

  public virtual void Hide()
  {
    if (_config.CacheType == CacheParametr.Destroy)
      Destroy(_element);
    else
      _element.SetActive(false);
  }

  protected virtual void OnCreate() { }

  protected virtual void OnShow() { }

  protected virtual void OnHide() { }
}
