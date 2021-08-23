using UI;
using UnityEngine;

public class MainGameManager : MonoBehaviour
{
  private void Awake() =>
    DontDestroyOnLoad(gameObject);

  void Start() =>
    UIManager.ShowNew(UIKey.MainMenu);    
}
