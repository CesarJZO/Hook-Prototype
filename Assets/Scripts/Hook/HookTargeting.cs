using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Hook
{
    public class HookTargeting : MonoBehaviour
    {
        [Header("Settings")]
        [SerializeField] private LayerMask targetLayerMask;
        [SerializeField, Min(0f)] private float radius;
        [SerializeField, Min(0f)] private float mouseTolerance;
        [SerializeField, Min(1)] private short maxTargets;
        [SerializeField] private bool useMouse;

        [Header("Debug")]
        [SerializeField] private bool showGizmos;
        [SerializeField] private bool showStats;
        [SerializeField, Min(0)] private int fontSize;
        [SerializeField] private Vector2 statsPosition;

        private Rect _statsRect;
        private GUIStyle _statStyle;

        private Collider2D[] _results;

        private Camera _mainCamera;
        private Mouse _mouse;

        /// <summary>
        /// Returns the nearest target in the radius.
        /// </summary>
        /// <returns>The nearest target if found within the circle area relative to the fire point position, null otherwise.</returns>
        public Transform GetNearestTarget()
        {
            if (!useMouse) return GetNearestTarget(transform.position, radius);

            if (!Application.isPlaying) return null;
            if (_mouse == null || !_mainCamera) return null;
            var mousePosition = _mainCamera.ScreenToWorldPoint(_mouse.position.ReadValue());
            return GetNearestTarget(mousePosition, mouseTolerance);
        }

        /// <summary>
        /// Returns the nearest target in the tolerance.
        /// </summary>
        /// <param name="t">The transform from which the target is going to be searched.</param>
        /// <param name="tolerance">The max allowed distance to accept targets.</param>
        /// <returns>If there are multiple targets within the range, it will return the nearest.</returns>
        public Transform GetNearestTarget(Transform t, float tolerance)
        {
            return GetNearestTarget(t.position, tolerance);
        }

        private Transform GetNearestTarget(Vector2 position, float tolerance)
        {
            var size = Physics2D.OverlapCircleNonAlloc(position, tolerance, _results, targetLayerMask);
            if (size == 0) return null;

            var min = float.MaxValue;
            Transform nearestTarget = null;
            foreach (var col in _results)
            {
                if (!col) break;
                var distance = Vector2.Distance(position, col.transform.position);
                if (distance > min) continue;
                min = distance;
                nearestTarget = col.transform;
            }

            return nearestTarget;
        }

        private void Awake()
        {
            _mainCamera = Camera.main;
            _mouse = Mouse.current;
        }

        private void OnValidate()
        {
            _results = new Collider2D[maxTargets];
            _statsRect = new Rect(statsPosition, Vector2.one);
            _statStyle = new GUIStyle
            {
                fontSize = fontSize,
                wordWrap = false,
                normal = { textColor = Color.white }
            };
        }

        private void OnDrawGizmos()
        {
            if (!showGizmos) return;

            var position = transform.position;
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(position, useMouse ? mouseTolerance : radius);

            var nearestTarget = GetNearestTarget();
            if (!nearestTarget) return;

            var targetPosition = nearestTarget.position;
            Gizmos.DrawIcon(targetPosition, "Assets/Media/UI/Cursor.png", default, Color.green);

            Gizmos.color = Color.black;
            Gizmos.DrawLine(position, targetPosition);
        }

        private void OnGUI()
        {
            if (!showStats) return;
            var currentTarget = GetNearestTarget();
            GUI.Label(
                _statsRect,
                $@"Current target: {(currentTarget ? currentTarget.name : "None")}
Targets found: [{string.Join(", ", _results.Select(col => !col ? "_" : col.name))}]",
                _statStyle
            );
        }
    }
}
