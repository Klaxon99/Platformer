using UnityEngine;

public class PlayerInputHandler : MonoBehaviour
{
    private readonly string Horizontal = nameof(Horizontal);
    private readonly string Vertical = nameof(Vertical);

    public float HorizontalInput { get; private set; }
    public bool VerticalInput { get; private set; }

    private void Update()
    {
        HorizontalInput = Input.GetAxis(Horizontal);
        VerticalInput = Input.GetKeyDown(KeyCode.Space);
    }
}