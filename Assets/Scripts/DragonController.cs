using UnityEngine;
using System.Collections;

namespace DragonFight
{
    [RequireComponent(typeof(DragonMovement))]
    [RequireComponent(typeof(DragonCombat))]
    [RequireComponent(typeof(DragonHealth))]
    [RequireComponent(typeof(DragonTargeting))]
    public class DragonController : MonoBehaviour
    {
        [SerializeField] private bool isPlayer;
        [SerializeField] private PlayerDragonInput playerInput;

        [SerializeField] private DragonMovement movement;
        [SerializeField] private DragonCombat combat;
        [SerializeField] private DragonHealth health;
        [SerializeField] private DragonTargeting targeting;

        public bool IsPlayer => isPlayer;
        public DragonHealth Health => health;

        private void Awake()
        {
            movement ??= GetComponent<DragonMovement>();
            combat ??= GetComponent<DragonCombat>();
            health ??= GetComponent<DragonHealth>();
            targeting ??= GetComponent<DragonTargeting>();

            if (isPlayer && playerInput == null)
                playerInput = GetComponent<PlayerDragonInput>();
        }

        private void Update()
        {
            if (health.IsDead)
            {
                movement.Stop();
                return;
            }

            if (!isPlayer || playerInput == null)
                return;

            Vector3 direction = new Vector3(
                playerInput.MoveInput.x,
                0f,
                playerInput.MoveInput.y
            );

            movement.Move(direction);

            if (!targeting.HasTarget())
                return;

            if (playerInput.BasicAttackPressed)
            {
                TryBasicAttack();
            }

            if (playerInput.FireAttackPressed)
            {
                TryFireAttack();
            }
        }

        private void TryBasicAttack()
        {
            StartCoroutine(FaceAndBasicAttack());
        }

        private void TryFireAttack()
        {
            StartCoroutine(FaceAndFireAttack());
        }

        private IEnumerator FaceAndBasicAttack()
        {
            Transform target = targeting.Target;

            yield return movement.FaceTarget(target);

            combat.TryBasicAttack();
        }

        private IEnumerator FaceAndFireAttack()
        {
            Transform target = targeting.Target;

            yield return movement.FaceTarget(target);

            combat.TryFireAttack();
        }

        public void SetTarget(Transform target)
        {
            targeting.SetTarget(target);
        }
    }
}
