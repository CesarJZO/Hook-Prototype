using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class JointChild : MonoBehaviour
    {
        [SerializeField] private new Rigidbody2D rigidbody;

        [SerializeField] private float downForce;
        [SerializeField] private float threshold;

        private void FixedUpdate()
        {
            if (rigidbody.velocity.magnitude < threshold)
            {
                rigidbody.AddForce(Vector2.down * downForce);
            }
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawRay(Vector3.right * 10, Vector3.up * rigidbody.velocity.magnitude);
        }
    }

}
