using UnityEngine;

namespace Kidvibe.Test
{
  public class PlayerDataStorage : MonoBehaviour
  {
    [SerializeField] private GameObject _playerTemplate;

    public static GameObject player;

    private void Awake()
    {
      player = _playerTemplate;
    }
  }
}

