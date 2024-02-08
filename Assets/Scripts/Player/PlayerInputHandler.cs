using System;
using UnityEngine;

public class PlayerInputHandler : MonoBehaviour
{
    private readonly string Horizontal = nameof(Horizontal);
    private readonly string Vertical = nameof(Vertical);
    private KeyCode _skillButton = KeyCode.LeftShift;

    public event Action OnPressedSkillButton;

    public float HorizontalInput { get; private set; }
    public bool VerticalInput { get; private set; }

    private void Update()
    {
        HorizontalInput = Input.GetAxis(Horizontal);
        VerticalInput = Input.GetKeyDown(KeyCode.Space);

        if (Input.GetKey(_skillButton))
        {
            OnPressedSkillButton?.Invoke();
        }
    }
}