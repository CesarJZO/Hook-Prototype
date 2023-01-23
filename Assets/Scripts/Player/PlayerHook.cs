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
        [SerializeField] private GameObject cursor;
        [SerializeField] private PlayerInput input;

        private LineRenderer _lineRenderer;
        private Collider2D[] _results;

        public bool Grappling => springJoint.enabled;

        private void Awake()
        {
            _results = new Collider2D[maxTargets];
            _lineRenderer = GetComponent<LineRenderer>();
            if (!springJoint)
            {
                springJoint = GetComponentInParent<SpringJoint2D>();
                springJoint.enabled = false;
            }

            if (cursor) cursor.SetActive(false);
        }

        private void Update()
        {
            var size = Physics2D.OverlapCircleNonAlloc(transform.position, radius, _results, targetLayer);
            if (size == 0)
            {
                currentTarget = null;
                return;
            }

            _lineRenderer.positionCount = 2;
            currentTarget = GetNearestTarget();

            var targetPos = currentTarget.position;

            cursor.transform.position = targetPos;
            springJoint.connectedAnchor = targetPos;
            springJoint.enabled = input.holdShoot;
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
            cursor.SetActive(currentTarget);
            if (!currentTarget) return;

            if (input.holdShoot)
            {
                _lineRenderer.SetPosition(0, transform.position);
                _lineRenderer.SetPosition(1, currentTarget.position);
            }
            else
            {
                _lineRenderer.positionCount = 0;
            }
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawWireSphere(transform.position, radius);
        }
    }
}
