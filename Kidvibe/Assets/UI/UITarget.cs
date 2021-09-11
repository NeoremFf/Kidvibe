using System;
using System.Collections.Generic;

namespace UI
{
  public class UITarget
  {
    public Dictionary<string, string> texts;

    public event Action OnSet;

    public UITarget() =>
      texts = new Dictionary<string, string>();

    public void Set(string key, string value)
    {
      texts[key] = value;

      OnSet?.Invoke();
    }
  }
}
