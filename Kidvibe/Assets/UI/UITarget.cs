using System;
using System.Collections.Generic;

namespace Kidvibe.UI
{
  public class UITarget
  {
    public Dictionary<string, string> texts;

    public event Action Setted;

    public UITarget() =>
      texts = new Dictionary<string, string>();

    public void Set(string key, string value)
    {
      texts[key] = value;

      Setted?.Invoke();
    }
  }
}
