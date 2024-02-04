using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] private float _movementSpeed;
    [SerializeField] private SpriteRenderer _spriteRenderer;

    public void Move(Vector3 direction)
    {
        Rotate(direction);

        transform.Translate(direction * _movementSpeed * Time.deltaTime);
    }

    public void MoveTowards(Vector3 target)
    {
        Rotate((target - transform.position).normalized);

        transform.position = Vector3.MoveTowards(transform.position, target, _movementSpeed * Time.deltaTime);
    }

    public void Rotate(Vector3 direction)
    {
        if (direction.x != 0)
        {
            _spriteRenderer.flipX = direction.x < 0;
        }
    }
}