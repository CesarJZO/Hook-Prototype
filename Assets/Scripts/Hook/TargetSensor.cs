using System.Linq;
using UnityEngine;

namespace Hook
{
    public class TargetSensor : MonoBehaviour
    {
        [Header("Settings")]
        [SerializeField] private LayerMask targetLayerMask;
        [SerializeField, Min(0f)] private float radius;
        [SerializeField, Min(0f)] private short maxTargets;

        [Header("Debug")]
        [SerializeField] private bool showGizmos;
        [SerializeField] private Color areaColor;
        [SerializeField] private Color targetColor;
        [SerializeField] private Color lineColor;
        [Space, SerializeField] private bool showStats;
        [SerializeField, Min(0)] private int fontSize;
        [SerializeField] private Vector2 statsPosition;

        private Rect _statsRect;
        private GUIStyle _statStyle;

        private Collider2D[] _results;

        /// <summary>
        /// Returns the nearest target in the radius.
        /// </summary>
        /// <returns>The nearest target if found within the circle area, null otherwise.</returns>
        public Transform GetNearestTarget()
        {
            var size = Physics2D.OverlapCircleNonAlloc(transform.position, radius, _results, targetLayerMask);
            if (size == 0) return null;

            var min = float.MaxValue;
            Transform nearestTarget = null;
            foreach (var col in _results)
            {
                if (!col) break;
                var distance = Vector3.Distance(transform.position, col.transform.position);
                if (distance > min) continue;
                min = distance;
                nearestTarget = col.transform;
            }

            return nearestTarget;
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
            var t = transform;
            Gizmos.color = areaColor;
            Gizmos.DrawWireSphere(t.position, radius);

            var nearestTarget = GetNearestTarget();
            if (!nearestTarget) return;

            var targetPosition = nearestTarget.position;
            Gizmos.color = targetColor;
            Gizmos.DrawIcon(targetPosition, "Assets/Media/UI/Cursor.png", false, targetColor);

            Gizmos.color = lineColor;
            Gizmos.DrawLine(t.position, targetPosition);
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
