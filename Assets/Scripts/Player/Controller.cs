using UnityEngine;
using UnityEngine.InputSystem;

namespace Player
{
    public class Controller : MonoBehaviour
    {
        [Header("Movement")]
        [SerializeField] float jumpForce;
        [SerializeField] float acceleration;
        [SerializeField] float maxSpeed;

        [Header("Physics")]
        [SerializeField] float groundDistance;
        [SerializeField] LayerMask groundMask;

        bool Grounded => Physics2D.Raycast(rigidbody.position, Vector2.down, groundDistance, groundMask);

        new Rigidbody2D rigidbody;
        PlayerInput playerInput;
        InputAction move;

        void Awake()
        {
            rigidbody = GetComponent<Rigidbody2D>();
            playerInput = GetComponent<PlayerInput>();
            move = playerInput.actions["Move"];
        }

        void FixedUpdate()
        {
            if (Mathf.Abs(rigidbody.velocity.x) <= maxSpeed)
                rigidbody.AddForce(Vector2.right * move.ReadValue<float>() * acceleration);
        }

        public void OnJump()
        {
            if (Grounded)
                rigidbody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }

        public void OnShoot()
        {

        }

        void OnDrawGizmos()
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawLine(transform.position, transform.position + Vector3.down * groundDistance);
        }
    }
}