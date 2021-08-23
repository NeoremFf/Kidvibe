using UnityEngine;

namespace Kidvibe.Test
{
  public class PlayerDataStorage : MonoBehaviour
  {
    [SerializeField] private GameObject _playerTemplate;

    [Header("Settings")]
    [SerializeField] private int _speed;
    [Header("Settings")] [SerializeField] private int _dashPower;

    public static int speed;
    public static int dashPower;

    public static GameObject player;

    private void Awake()
    {
      speed = _speed;
      dashPower = _dashPower;
      player = _playerTemplate;
    }
  }
}

