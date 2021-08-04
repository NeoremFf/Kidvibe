namespace UI
{
  public class UIConfiguration
  {
    public ShowParametr Show = ShowParametr.HideAll;

    public HideParametr Hide = HideParametr.Common;

    public CacheParametr CacheType = CacheParametr.Cached;
  }

  /// <summary>
  /// 
  /// </summary>
  public enum ShowParametr
  {
    HideNothing,
    HideAll,
    ForcedHideAll,
  }

  /// <summary>
  /// 
  /// </summary>
  public enum HideParametr
  {
    NeverHide,
    Common,
    AlwaysHide,
  }

  public enum CacheParametr
  {
    Cached,
    Destroy,
  }
}
