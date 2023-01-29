using Input;
using UnityEngine;

namespace Hook
{
    [RequireComponent(typeof(HookTargeting))]
    public class Hook : MonoBehaviour
    {
        [Header("Status")]
        public Transform currentTarget;

        [Header("Settings")]
        public float launchSpeed;
        public Transform firePoint;

        [Header("Dependencies")]
        [SerializeField] private SpringJoint2D springJoint;
        private HookTargeting _hookTargeting;
        private PlayerActions _input;

        private void Awake()
        {
            if (!_hookTargeting) _hookTargeting = GetComponent<HookTargeting>();
        }

        private void Start()
        {
            if (springJoint) springJoint.enabled = false;

            _input = new PlayerActions();
            var ground = _input.Ground;
            ground.Enable();
            ground.Shoot.performed += _ => OnShootPerformed();
            ground.Shoot.canceled += _ => OnShootCanceled();
        }

        private void OnShootPerformed()
        {
            currentTarget = _hookTargeting.GetNearestTarget();
            if (!currentTarget) return;

            if (!springJoint)
            {
                Debug.LogWarning("SpringJoint2D not set!");
                return;
            }

            springJoint.connectedAnchor = currentTarget.position;
            springJoint.autoConfigureDistance = false;
            springJoint.distance = 0f;
            springJoint.frequency = launchSpeed;
            springJoint.enabled = true;
        }

        private void OnShootCanceled()
        {
            currentTarget = null;
            springJoint.enabled = false;
        }
    }
}
