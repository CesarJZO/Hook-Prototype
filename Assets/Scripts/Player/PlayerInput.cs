using Input;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Player
{
    public class PlayerInput : MonoBehaviour
    {
        private PlayerActions _playerActions;
        [SerializeField] private Player player;

        private void OnEnable()
        {
            player = GetComponentInParent<Player>();

            var ground = _playerActions.Ground;
            ground.Enable();
            ground.Jump.performed += OnJumpPerformed;
            ground.Shoot.performed += OnShootPerformed;
        }

        private void OnDisable()
        {
            var ground = _playerActions.Ground;
            ground.Enable();
            ground.Jump.performed -= OnJumpPerformed;
            ground.Shoot.performed -= OnShootPerformed;
        }

        #region Event functions

        private void OnJumpPerformed(InputAction.CallbackContext obj)
        {
            player.CurrentState.ReadInput(obj, InputCommand.Jump);
        }

        private void OnShootPerformed(InputAction.CallbackContext obj)
        {
            player.CurrentState.ReadInput(obj, InputCommand.Shoot);
        }

        #endregion
    }

    public enum InputCommand
    {
        None,
        Jump,
        Shoot
    }
}
