using System;
using System.Collections.Generic;

public class UITerget_test
{
  public Dictionary<string, string> texts;

  public event Action OnSet;

  public UITerget_test() =>
    texts = new Dictionary<string, string>();

  public void Set(string key, string value)
  {
    texts[key] = value;

    OnSet?.Invoke();
  }
}
