using System;
using UnityEngine;

namespace DragonFight
{
    public class DragonHealth : MonoBehaviour, IDamageable
    {
        [SerializeField] private DragonStats stats;
        [SerializeField] private DragonAnimator dragonAnimator;

        public float CurrentHealth { get; private set; }
        public float MaxHealth => stats != null ? stats.maxHealth : 0f;
        public bool IsDead { get; private set; }

        public event Action<float, float> OnHealthChanged;
        public event Action<DragonHealth> OnDeath;

        private void Awake()
        {
            if (dragonAnimator == null)
                dragonAnimator = GetComponent<DragonAnimator>();

            ResetHealth();
        }

        public void ResetHealth()
        {
            IsDead = false;
            CurrentHealth = MaxHealth;
            OnHealthChanged?.Invoke(CurrentHealth, MaxHealth);
        }

        public void TakeDamage(float amount, GameObject source)
        {
            if (IsDead || amount <= 0f) return;

            CurrentHealth = Mathf.Max(0f, CurrentHealth - amount);
            OnHealthChanged?.Invoke(CurrentHealth, MaxHealth);

            if (CurrentHealth <= 0f)
            {
                IsDead = true;
                dragonAnimator?.PlayDeath();
                OnDeath?.Invoke(this);
                return;
            }

            dragonAnimator?.PlayHit();
        }
    }
}
