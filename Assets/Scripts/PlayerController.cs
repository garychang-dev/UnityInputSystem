using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;

    public float jumpForce;

    private Rigidbody m_Rigidbody;
    private Vector3 m_Direction;

    private void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        Vector3 offset = m_Direction * speed * Time.deltaTime;
        Vector3 nextPosition = transform.position + offset;
        m_Rigidbody.MovePosition(nextPosition);
    }

    public void Move(Vector3 direction)
    {
        m_Direction = direction;
    }

    public void Jump()
    {
        m_Rigidbody.AddForce(Vector3.up * jumpForce);
    }
}
