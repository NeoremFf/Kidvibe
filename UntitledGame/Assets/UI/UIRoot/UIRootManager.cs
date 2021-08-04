using UnityEngine;

public class UIRootManager : MonoBehaviour
{
  private void Start() =>
    DontDestroyOnLoad(gameObject);
}
