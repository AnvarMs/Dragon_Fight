using UnityEngine;

namespace DragonFight
{
    public class DragonCombat : MonoBehaviour
    {
        [SerializeField] private DragonStats stats;
        [SerializeField] private DragonAnimator dragonAnimator;
        [SerializeField] private DragonTargeting targeting;
        [SerializeField] private LayerMask damageableLayers = ~0;

        private float basicTimer;
        private float fireTimer;

        public float BasicCooldownRemaining => Mathf.Max(0f, basicTimer);
        public float FireCooldownRemaining => Mathf.Max(0f, fireTimer);

        public float BasicCooldownDuration =>
            stats != null ? stats.basicAttackCooldown : 0f;

        public float FireCooldownDuration =>
            stats != null ? stats.fireCooldown : 0f;
        private void Awake()
        {
            if (dragonAnimator == null) dragonAnimator = GetComponent<DragonAnimator>();
            if (targeting == null) targeting = GetComponent<DragonTargeting>();
        }

        private void Update()
        {
            basicTimer -= Time.deltaTime;
            fireTimer -= Time.deltaTime;
        }

        public bool TryBasicAttack()
        {
            if (stats == null ||
                targeting == null ||
                !targeting.HasTarget() ||
                basicTimer > 0f)
            {
                return false;
            }

            Transform target = targeting.Target;

            Vector3 direction = target.position - transform.position;
            direction.y = 0f;

            float distance = direction.magnitude;

            // Target is outside melee range
            if (distance > stats.basicAttackRange)
                return false;

            DragonHealth targetHealth =
                target.GetComponentInParent<DragonHealth>();

            if (targetHealth == null)
            {
                Debug.LogWarning(
                    $"{name}: Target does not have DragonHealth."
                );

                return false;
            }

            // Start cooldown
            basicTimer = stats.basicAttackCooldown;

            // Play animation
            dragonAnimator?.PlayBasicAttack();

            // Deal damage
            targetHealth.TakeDamage(
                stats.basicAttackDamage,
                gameObject
            );

            Debug.Log(
                $"{name} basic attacked {target.name} for {stats.basicAttackDamage} damage."
            );

            return true;
        }

        public bool TryFireAttack()
        {
            if (stats == null || targeting == null || !targeting.HasTarget() || fireTimer > 0f)
                return false;

            Transform target = targeting.Target;
            Vector3 direction = target.position - transform.position;
            direction.y = 0f;

            float distance = direction.magnitude;
            if (distance > stats.fireRange || distance < 0.01f)
                return false;

            float angle = Vector3.Angle(transform.forward, direction.normalized);
            if (angle > stats.fireAngle * 0.5f)
                return false;

            fireTimer = stats.fireCooldown;
            dragonAnimator?.PlayFireAttack();

            DragonHealth health = target.GetComponentInParent<DragonHealth>();
            health?.TakeDamage(stats.fireDamage, gameObject);

            return true;
        }

        private void DamageTargetFromHits(
            Collider[] hits,
            Transform target,
            float damage)
        {
            foreach (Collider hit in hits)
            {
                DragonHealth health = hit.GetComponentInParent<DragonHealth>();
                if (health == null || health.gameObject == gameObject)
                    continue;

                if (target != null &&
                    health.transform != target &&
                    !health.transform.IsChildOf(target) &&
                    !target.IsChildOf(health.transform))
                    continue;

                health.TakeDamage(damage, gameObject);
                return;
            }
        }
    }
}
