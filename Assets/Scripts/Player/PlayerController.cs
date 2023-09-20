using UnityEngine;
using UnityEngine.InputSystem;

namespace Player
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private PlayerSettings settings;

        [SerializeField] private PlayerInput input;

        private Rigidbody2D _rigidbody;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
        }

        private void Start()
        {
            input.Jump += OnJump;
        }

        private void OnJump(InputAction.CallbackContext obj)
        {
            _rigidbody.AddForce(Vector2.up * settings.JumpForce, ForceMode2D.Impulse);
        }

        private void FixedUpdate()
        {
            float direction = input.Direction;

            _rigidbody.AddForce(Vector2.right * (direction * settings.Speed));
        }
    }
}
