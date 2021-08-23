using UnityEngine;

namespace Assets.PlayerController
{
  public class PlayerController : MonoBehaviour
  {
    [Header("Player Values")]
    [SerializeField] private float _speed = 1;
    [SerializeField] private float _dashPower = 1;

    private Rigidbody2D _rb;

    private Vector2 _moveDirection;

    [Header("Dash Values")]
    [SerializeField]  private float _dashCd = 1;
    [SerializeField]  private float _dashDuration = .5f;
    private float _dashCdTimer = 0;
    private float _dashDurationTimer = 0;
    private bool _isDash = false;

    private void Start()
    {
      _rb = GetComponentInChildren<Rigidbody2D>();
    }

    private void Update()
    {
      _moveDirection = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
      _moveDirection = _moveDirection.normalized;

      if (_dashCdTimer <= 0 && Input.GetKeyDown(KeyCode.LeftShift))
        Dash(_moveDirection);
      else
        _dashCdTimer -= Time.deltaTime;

      if (_dashDurationTimer > 0)
        _dashDurationTimer -= Time.deltaTime;
      else
        _isDash = false;
    }

    private void FixedUpdate()
    {
      if (!_isDash)
        _rb.velocity = _moveDirection * _speed;
    }

    private void Dash(Vector2 dir)
    {
      if (dir == Vector2.zero)
        return;

      _dashCdTimer = _dashCd;
      _dashDurationTimer = _dashDuration;

      var impulse = dir * _dashPower;
      _rb.AddForce(impulse, ForceMode2D.Impulse);

      _isDash = true;
    }
  }
}