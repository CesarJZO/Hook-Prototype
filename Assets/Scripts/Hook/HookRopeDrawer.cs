using UnityEngine;

namespace Hook
{
    [RequireComponent(typeof(LineRenderer))]
    public class HookRopeDrawer : MonoBehaviour
    {
        [Header("Settings")]
        [SerializeField] private int precision;
        // [SerializeField] private float straightenLineSpeed;

        [Header("Animation")]
        [SerializeField] private AnimationCurve animationCurve;
        [SerializeField, Range(0.01f, 4f)] private float startWaveSize;
        private float _waveSize;

        [Header("Progression")]
        [SerializeField] private AnimationCurve ropeProgression;
        [SerializeField, Range(1f, 50f)] private float ropeProgressionSpeed;

        private float _moveTime;

        [Header("Dependencies")]
        [SerializeField] private LineRenderer lineRenderer;
        [SerializeField] private Hook hook;

        private bool _straightLine = true;

        private void OnEnable()
        {
            if (!lineRenderer) lineRenderer = GetComponent<LineRenderer>();
            _moveTime = 0f;
            lineRenderer.positionCount = precision;
            _waveSize = startWaveSize;
            _straightLine = false;

            LinePointsToFirePoint();

            lineRenderer.enabled = true;
        }

        private void Update()
        {
            _moveTime += Time.deltaTime;
            DrawRope();
        }

        private void OnDisable()
        {
            lineRenderer.enabled = false;
        }

        private void LinePointsToFirePoint()
        {
            for (var i = 0; i < precision; i++)
                lineRenderer.SetPosition(i, hook.currentTarget.position);
        }

        private void DrawRope()
        {
            if (!hook.currentTarget) return;

            if (_straightLine)
            {
                DrawRopeStraight();
                return;
            }

            var direction = hook.currentTarget.position - hook.firePoint.position;
            DrawRopeWaves(direction);
        }

        private void DrawRopeWaves(Vector2 direction)
        {
            lineRenderer.positionCount = precision;
            for (short i = 0; i < precision; i++)
            {
                var delta = i / (precision - 1f);
                var offset = Vector2.Perpendicular(direction.normalized) * (animationCurve.Evaluate(delta) * _waveSize);

                Vector2 firePoint = hook.firePoint.position;
                Vector2 targetPoint = hook.currentTarget.position;

                var targetPosition = Vector2.Lerp(firePoint, targetPoint, delta) + offset;
                var currentPosition = Vector2.Lerp(firePoint, targetPosition, ropeProgression.Evaluate(_moveTime) * ropeProgressionSpeed);

                lineRenderer.SetPosition(i, currentPosition);
            }
        }

        private void DrawRopeStraight()
        {
            lineRenderer.positionCount = 2;
            lineRenderer.SetPosition(0, hook.firePoint.position);
            lineRenderer.SetPosition(1, hook.currentTarget.position);
        }
    }
}
