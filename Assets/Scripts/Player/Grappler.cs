using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Grappler : MonoBehaviour
{
    [SerializeField] float dampingRatio;
    [SerializeField] LayerMask grappeable;
    [SerializeField] Actions actions;
    CircleCollider2D anchorSensor;
    float maxDistance;
    LineRenderer line;
    Vector2 grapplingPoint;
    SpringJoint2D springJoint;

    PlayerInput playerInput;
    InputAction shootAction;

    void Awake()
    {
        anchorSensor = GetComponentInChildren<CircleCollider2D>();
        maxDistance = anchorSensor.radius;
        line = GetComponent<LineRenderer>();
        playerInput = GetComponent<PlayerInput>();
        springJoint = gameObject.AddComponent<SpringJoint2D>();
        springJoint.enabled = false;
        shootAction = playerInput.actions[actions.shoot];
    }
    void Update()
    {
        if (shootAction.WasReleasedThisFrame())
            StopGrapple();
    }

    void LateUpdate()
    {
        DrawRope();
    }

    void StartGrapple()
    {
        if (grapplingPoint == Vector2.zero) return;
        springJoint.enabled = true;
        springJoint.autoConfigureConnectedAnchor = false;
        springJoint.connectedAnchor = grapplingPoint;

        // springJoint.distance = Vector2.Distance(transform.position, grapplingPoint);

        springJoint.dampingRatio = dampingRatio;
        line.positionCount = 2;
        
    }

    void StopGrapple()
    {
        line.positionCount = 0;
        grapplingPoint = Vector2.zero;
        springJoint.enabled = false;
    }

    void DrawRope()
    {   // todo: Use a for loop and make this look more curved and natural
        if (!springJoint.enabled || grapplingPoint == Vector2.zero) return;
        line.SetPosition(0, transform.position);
        line.SetPosition(1, grapplingPoint);
    }

    void OnTriggerStay2D(Collider2D collider)
    {
        if (shootAction.WasPressedThisFrame() && grapplingPoint == Vector2.zero)
        {
            grapplingPoint = collider.transform.position;
            StartGrapple();
        }
    }
}

