using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
    private Controls m_Controls;

    private PlayerController m_PlayerController;
    void Awake()
    {
        m_Controls = new Controls();
        m_PlayerController = GetComponent<PlayerController>();

        // Action Type: Action Asset
        m_Controls.Player.Jump.performed += OnJump;
    }

    void OnEnable()
    {
        m_Controls.Enable();
    }

    void OnDisable()
    {
        m_Controls.Disable();
    }
    
    void Update()
    {
        // Action Type: Value
        Vector2 inputDirection = m_Controls.Player.Move.ReadValue<Vector2>();
        Vector3 direction = new Vector3(inputDirection.x, 0f, inputDirection.y);
        direction = Vector3.ClampMagnitude(direction, 1f);

        m_PlayerController.Move(direction);
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        m_PlayerController.Jump();
    }
}
