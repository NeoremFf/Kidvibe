using UnityEditorInternal;
using UnityEngine;

public class UIRootManager : MonoBehaviour
{
  public Canvas Canvas { get; private set; }

  private void Awake()
  {
    DontDestroyOnLoad(gameObject);

    Canvas = GameObject.FindObjectOfType<Canvas>();
  }
}
