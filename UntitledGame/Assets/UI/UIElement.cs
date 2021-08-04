using UnityEngine;
using UI;

public class UIElement : MonoBehaviour
{
  public GameObject Element =>
    _element;

  public bool HideOther => _config.Show == ShowParametr.HideAll || ForcedHideOther;
  public bool ForcedHideOther => _config.Show == ShowParametr.ForcedHideAll;

  public bool NeverHide => _config.Hide == HideParametr.NeverHide;

  private GameObject _element;

  private UIConfiguration _config;

  protected virtual void Create(GameObject template)
  {
    _element = gameObject;

    _element.SetActive(false);
  }

  public virtual void Init(UIConfiguration configs)
  {
    _config = configs;

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
