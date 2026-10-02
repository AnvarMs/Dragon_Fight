using UnityEngine;

namespace DragonFight
{
    public class DragonAI : MonoBehaviour
    {
        private enum State { Chase, Attack, Dead }

        [SerializeField] private DragonStats stats;
        [SerializeField] private DragonMovement movement;
        [SerializeField] private DragonCombat combat;
        [SerializeField] private DragonHealth health;
        [SerializeField] private DragonTargeting targeting;

        private State state;

        private void Awake()
        {
            movement ??= GetComponent<DragonMovement>();
            combat ??= GetComponent<DragonCombat>();
            health ??= GetComponent<DragonHealth>();
            targeting ??= GetComponent<DragonTargeting>();

            health.OnDeath += HandleDeath;
        }

        private void OnDestroy()
        {
            if (health != null)
                health.OnDeath -= HandleDeath;
        }

        private void Update()
        {
            if (health.IsDead)
            {
                state = State.Dead;
                movement.Stop();
                return;
            }

            if (!targeting.HasTarget() || stats == null)
            {
                movement.Stop();
                return;
            }

            float distance = targeting.DistanceToTarget();

            if (distance > stats.detectionRange)
            {
                movement.Stop();
                return;
            }

            if (distance > stats.preferredAttackDistance)
            {
                state = State.Chase;

                Vector3 direction =
                    targeting.Target.position - transform.position;
                direction.y = 0f;

                movement.Move(direction);
                movement.FaceTarget(targeting.Target);
            }
            else
            {
                state = State.Attack;
                movement.Stop();
                movement.FaceTarget(targeting.Target);

                combat.TryBasicAttack();
                combat.TryFireAttack();
            }
        }

        private void HandleDeath(DragonHealth deadDragon)
        {
            state = State.Dead;
            movement.Stop();
        }
    }
}
