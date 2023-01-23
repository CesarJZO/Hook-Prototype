using System;
using UnityEngine;

namespace Player
{
    [Serializable]
    public struct PlayerSettings
    {
        public float speed;
        public float jumpForce;

        public LayerMask groundLayerMask;
        public float groundDistance;
    }
}
