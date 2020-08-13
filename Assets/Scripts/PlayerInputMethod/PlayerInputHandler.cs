using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputHandler : MonoBehaviour
{
    private PlayerInput m_PlayerInput;
    private PlayerController m_PlayerController;

    void Awake()
    {
        m_PlayerInput = GetComponent<PlayerInput>();
        var playerControllers = FindObjectsOfType<PlayerController>();
        m_PlayerController = playerControllers.FirstOrDefault(p => p.playerIndex == m_PlayerInput.playerIndex);
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        if (m_PlayerController != null)
        {
            Vector2 inputDirection = context.ReadValue<Vector2>();
            Vector3 direction = new Vector3(inputDirection.x, 0f, inputDirection.y);
            direction = Vector3.ClampMagnitude(direction, 1f);

            m_PlayerController.Move(direction);
        }
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        m_PlayerController.Jump();
    }
}
