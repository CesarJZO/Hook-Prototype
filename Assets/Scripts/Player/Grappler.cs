using UnityEngine;
using UnityEngine.InputSystem;

public class Grappler : MonoBehaviour
{
    public GameObject cursorTemplate;
    public LayerMask Anchors;
    private bool grappling;
    private LineRenderer lineRenderer;
    private GameObject currentCursor;
    private CircleCollider2D hookArea;
    private SpringJoint2D springJoint;
    private PlayerInput playerInput;
    private InputAction shootAction;

    void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();
        hookArea = GetComponent<CircleCollider2D>();
        springJoint = GetComponentInParent<SpringJoint2D>();
        springJoint.enabled = false;
        playerInput = GetComponentInParent<PlayerInput>();
        shootAction = playerInput.actions[Actions.Shoot];
    }

    void Update()
    {
        if (shootAction.WasPressedThisFrame() && currentCursor != null && currentCursor.transform.position != Vector3.zero)
            StartGrapple();
        else if (shootAction.WasReleasedThisFrame())
            StopGrapple();
    }

    void LateUpdate()
    {
        if (grappling)
            DrawRope();
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (hookArea.IsTouchingLayers(Anchors) && currentCursor == null)
            currentCursor = Instantiate(cursorTemplate, collider.transform);
    }

    void StartGrapple()
    {
        grappling = true;
        springJoint.enabled = true;
        springJoint.connectedAnchor = currentCursor.transform.position;
        lineRenderer.positionCount = 2;
    }

    void StopGrapple()
    {
        grappling = false;
        lineRenderer.positionCount = 0;
        springJoint.enabled = false;
    }

    void DrawRope()
    {
        lineRenderer.SetPosition(0, transform.position);
        lineRenderer.SetPosition(1, springJoint.connectedAnchor);
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        if (currentCursor != null)
            Destroy(currentCursor);
    }
}
