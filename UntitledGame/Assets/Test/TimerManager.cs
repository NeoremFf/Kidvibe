using System.Collections;
using UnityEngine;
using UI;

public class TimerManager : MonoBehaviour
{
  [SerializeField] private GameObject _uiPrefab;

  private int _time = 0;

  private UITerget_test _ui;

  void Start()
  {
    _ui = new UITerget_test();

    var uiElement = Instantiate(_uiPrefab, UIManager.RootTransform);
    uiElement.GetComponent<UIElement_test>().Init(_ui);

    StartCoroutine(Timer());
  }

  private IEnumerator Timer()
  {
    while (true)
    {
      yield return new WaitForSeconds(1);

      ++_time;
      _ui.Set("Time", _time.ToString());
    }
  }
}
