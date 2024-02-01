using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private const string Horizontal = nameof(Horizontal);

    [SerializeField] private float _movementSpeed;
    [SerializeField] private float _jumpForce;
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private Rigidbody2D _rigidBody;
    [SerializeField] private PlayerAnimator _animator;

    private Player _player;

    private void Start()
    {
        _player = GetComponent<Player>();
    }

    private void Update()
    {
        if (_player.IsAlive)
        {
            Jump();
            Move();
        }
    }

    private void Move()
    {
        Vector2 direction = new Vector2(Input.GetAxis(Horizontal), 0);

        transform.Translate(direction * _movementSpeed * Time.deltaTime);

        if (direction.x != 0)
        {
            _spriteRenderer.flipX = direction.x > 0;
            _animator.PlayRunningAnimation();
        }
        else
        {
            _animator.StopRunningAnimation();
        }
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _rigidBody.AddForce(Vector2.up * _jumpForce);
        }
    }
}