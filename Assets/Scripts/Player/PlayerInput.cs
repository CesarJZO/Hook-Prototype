using System;
using Input;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Player
{
    public class PlayerInput : MonoBehaviour
    {
        private PlayerActions _playerActions;
        [SerializeField] private Player player;
        [Range(0f, 1f)] public float deadZone;
        public float Direction => _playerActions.Ground.Move.ReadValue<float>();
        public bool HoldShoot { get; private set; }


        private void Awake()
        {
            if (!player) player = GetComponentInParent<Player>();

            _playerActions = new PlayerActions();
        }

        private void OnEnable()
        {
            var ground = _playerActions.Ground;
            ground.Enable();
            ground.Jump.performed += OnJumpPerformed;
            ground.Shoot.performed += OnShootPerformed;
        }

        private void OnDisable()
        {
            var ground = _playerActions.Ground;
            ground.Disable();
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
            HoldShoot = obj.performed;
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
