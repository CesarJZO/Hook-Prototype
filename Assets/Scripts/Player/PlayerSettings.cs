using System;
using UnityEngine;

namespace Player
{
    [Serializable]
    public struct PlayerSettings
    {
        public float speed;
        public float jumpForce;
        [Range(0f, 1f)] public float airInputInfluence;

        public LayerMask groundLayerMask;
        public float groundDistance;
    }
}
