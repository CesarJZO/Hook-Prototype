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
            _lineRenderer = GetComponent<LineRenderer>();
            if (!springJoint) springJoint = GetComponentInParent<SpringJoint2D>();
        }

        private void Update()
        {
            _results = Physics2D.OverlapCircleAll(transform.position, radius, targetLayer);

            if (_results.Length == 0)
            {
                currentTarget = null;
                return;
            }

            currentTarget = GetNearestTarget();
        }

        private Transform GetNearestTarget()
        {
            var min = radius * 2f;
            Transform nearestTarget = null;
            foreach (var col in _results)
            {
                var distance = Vector3.Distance(transform.position, col.transform.position);
                if (distance > min) continue;
                min = distance;
                nearestTarget = col.transform;
            }

            return nearestTarget;
        }

        private void OnGUI()
        {
            GUI.Label(new Rect(0f, 0f, 1f,1f),
                $@"Current target: {(currentTarget ? currentTarget.name : "None")}
Targets found: [{string.Join(", ", _results.Select(col => col.name))}]",
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
            // if (!grappling) return;
            // _lineRenderer.SetPosition(0, transform.position);
            // _lineRenderer.SetPosition(0, springJoint.connectedAnchor);
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawWireSphere(transform.position, radius);
        }
    }
}
