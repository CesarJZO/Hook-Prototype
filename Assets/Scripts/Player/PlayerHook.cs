using System.Linq;
using UnityEngine;

namespace Player
{
    public class PlayerHook : MonoBehaviour
    {
        [SerializeField] private float radius;
        [SerializeField] private LayerMask targetLayer;
        [SerializeField] private short maxTargets;
        [SerializeField] private Transform currentTarget;

        [Header("Dependencies")]
        [SerializeField] private SpringJoint2D springJoint;

        private LineRenderer _lineRenderer;
        private Collider2D[] _results;

        private void Awake()
        {
            _results = new Collider2D[maxTargets];
            _lineRenderer = GetComponent<LineRenderer>();
            if (!springJoint) springJoint = GetComponentInParent<SpringJoint2D>();
        }

        private void Update()
        {
            var size = Physics2D.OverlapCircleNonAlloc(transform.position, radius, _results, targetLayer);
            if (size == 0)
            {
                _lineRenderer.positionCount = 0;
                currentTarget = null;
            }
            else
            {
                _lineRenderer.positionCount = 2;
                currentTarget = GetNearestTarget();
            }
        }

        private Transform GetNearestTarget()
        {
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

        private void OnGUI()
        {
            GUI.Label(new Rect(0f, 0f, 1f, 1f),
                $@"Current target: {(currentTarget ? currentTarget.name : "None")}
Targets found: [{string.Join(", ", _results.Select(col => !col ? "x" : col.name))}]",
                new GUIStyle
                {
                    fontSize = 16,
                    wordWrap = false,
                    normal = { textColor = Color.white }
                }
            );
        }

        private void LateUpdate()
        {
            if (_lineRenderer.positionCount == 0) return;

            _lineRenderer.SetPosition(0, transform.position);
            _lineRenderer.SetPosition(1, currentTarget.position);
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawWireSphere(transform.position, radius);
        }
    }
}
