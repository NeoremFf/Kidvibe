using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIElement_test : MonoBehaviour
{
  [SerializeField] private string[] _keys;
  [SerializeField] private Text[] _values;

  private Dictionary<string, Text> _texts;

  private UITerget_test _target;

  public void Init(UITerget_test target) =>
    _target = target;

  private void Start()
  {
    _texts = new Dictionary<string, Text>();

    for (var i = 0; i < _keys.Length; i++)
    {
      _texts[_keys[i]] = _values[i];
    }

    _target.OnSet += UpdateUI;
  }

  private void UpdateUI()
  {
    foreach (var text in _texts)
    {
      text.Value.text = _target.texts[text.Key];
    }
  }

  public void Set(string key, string newValue)
  {
    if (!_texts.ContainsKey(key))
      throw new System.Exception();

    _texts[key].text = newValue;
  }
}
