using UnityEngine;

namespace Player
{
    [CreateAssetMenu(fileName = "New Player Settings", menuName = "Player/Settings", order = 0)]
    public class PlayerSettings : ScriptableObject
    {
        [field: SerializeField] public float Speed { get; private set; }
        [field: SerializeField] public float JumpForce { get; private set; }
        [field: SerializeField, Range(0f, 1f)] public float AirInputInfluence { get; private set; }
        [field: SerializeField] public LayerMask groundLayerMask { get; private set; }
        [field: SerializeField] public float groundDistance { get; private set; }
    }
}
