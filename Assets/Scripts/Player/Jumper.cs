using UnityEngine;

[RequireComponent (typeof(Rigidbody2D))]
public class Jumper : MonoBehaviour
{
    [SerializeField] private float _jumpForce;
    [SerializeField] private Rigidbody2D _rigidbody;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    public void Jump()
    {
        _rigidbody.AddForce(Vector3.up * _jumpForce);
    }
}