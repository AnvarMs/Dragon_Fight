using UnityEngine;

namespace DragonFight
{
    [RequireComponent(typeof(Animator))]
    public class DragonAnimator : MonoBehaviour
    {
        [SerializeField] private Animator animator;

        private static readonly int SpeedHash = Animator.StringToHash("Speed");
        private static readonly int AttackHash = Animator.StringToHash("BasicAttack");
        private static readonly int FireHash = Animator.StringToHash("FireAttack");
        private static readonly int HitHash = Animator.StringToHash("GetHit");
        private static readonly int DeathHash = Animator.StringToHash("Die");

        private void Awake()
        {
            if (animator == null)
                animator = GetComponent<Animator>();
        }

        public void SetSpeed(float value)
        {
            if (animator != null) animator.SetFloat(SpeedHash, value);
        }

        public void PlayBasicAttack()
        {
            if (animator != null) animator.SetTrigger(AttackHash);
        }

        public void PlayFireAttack()
        {
            if (animator != null) animator.SetTrigger(FireHash);
        }

        public void PlayHit()
        {
            if (animator != null) animator.SetTrigger(HitHash);
        }

        public void PlayDeath()
        {
            if (animator != null) animator.SetTrigger(DeathHash);
        }
    }
}
