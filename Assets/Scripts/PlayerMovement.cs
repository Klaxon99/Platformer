using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private const string Horizontal = nameof(Horizontal);

    [SerializeField] private float _movementSpeed;
    [SerializeField] private float _jumpForce;
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private Rigidbody2D _rigidBody;
    [SerializeField] private PlayerAnimator _animator;

    private void Update()
    {
        Move();
        Jump();
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