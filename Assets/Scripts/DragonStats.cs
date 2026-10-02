using UnityEngine;

namespace DragonFight
{
    [CreateAssetMenu(fileName = "DragonStats", menuName = "Dragon Fight/Dragon Stats")]
    public class DragonStats : ScriptableObject
    {
        [Header("Health")]
        [Min(1f)] public float maxHealth = 100f;

        [Header("Movement")]
        [Min(0f)] public float moveSpeed = 6f;
        [Min(0f)] public float rotationSpeed = 720f;

        [Header("Basic Attack")]
        [Min(0f)] public float basicAttackDamage = 15f;
        [Min(0.1f)] public float basicAttackCooldown = 1f;
        [Min(0f)] public float basicAttackRange = 3f;
        [Min(0f)] public float basicAttackRadius = 1.25f;

        [Header("Fire Attack")]
        [Min(0f)] public float fireDamage = 25f;
        [Min(0.1f)] public float fireCooldown = 3f;
        [Min(0f)] public float fireRange = 8f;
        [Range(1f, 180f)] public float fireAngle = 45f;

        [Header("AI")]
        [Min(0f)] public float detectionRange = 20f;
        [Min(0f)] public float preferredAttackDistance = 3f;
    }
}
