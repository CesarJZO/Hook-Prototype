using System;
using Input;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Player
{
    public class PlayerInput : MonoBehaviour
    {
        public event Action<InputAction.CallbackContext> Jump;

        private PlayerActions _playerActions;
        [SerializeField] private Player player;
        [Range(0f, 1f)] public float deadZone;

        public float Direction => _playerActions.Ground.Move.ReadValue<float>();
        public bool holdShoot;


        public InputAction Shoot => _playerActions.Ground.Shoot;

        private void Awake()
        {
            if (!player)
                player = GetComponentInParent<Player>();

            _playerActions = new PlayerActions();
        }

        private void OnEnable()
        {
            var ground = _playerActions.Ground;
            ground.Enable();
            ground.Jump.performed += OnJumpPerformed;
            ground.Shoot.performed += OnShootPerformed;
            ground.Shoot.canceled += OnShootCanceled;
        }

        private void OnDisable()
        {
            var ground = _playerActions.Ground;
            ground.Disable();
            ground.Jump.performed -= OnJumpPerformed;
            ground.Shoot.performed -= OnShootPerformed;
            ground.Shoot.canceled -= OnShootCanceled;
        }

        #region Event functions

        private void OnJumpPerformed(InputAction.CallbackContext obj)
        {
            if (!player) return;
            player.CurrentState.ReadInput(obj, InputCommand.Jump);
        }

        private void OnShootPerformed(InputAction.CallbackContext obj)
        {
            if (!player) return;
            holdShoot = true;
            player.CurrentState.ReadInput(obj, InputCommand.Shoot);
        }

        private void OnShootCanceled(InputAction.CallbackContext obj)
        {
            holdShoot = false;
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
