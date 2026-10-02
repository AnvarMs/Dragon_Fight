using UnityEngine;
using UnityEngine.UI;

namespace DragonFight
{
    public class DragonHealthBarUI : MonoBehaviour
    {
        [SerializeField] private DragonHealth targetHealth;
        [SerializeField] private Slider healthSlider;

        [Header("Smooth Transition")]
        [SerializeField] private bool smoothTransition = true;
        [SerializeField] private float smoothSpeed = 8f;

        private float targetHealthValue;

        private void OnEnable()
        {
            if (targetHealth == null)
                return;

            targetHealth.OnHealthChanged += OnHealthChanged;
        }

        private void Start()
        {
            if (targetHealth == null)
            {
                Debug.LogError($"{name}: DragonHealth is not assigned.");
                enabled = false;
                return;
            }

            healthSlider.minValue = 0f;
            healthSlider.maxValue = targetHealth.MaxHealth;

            targetHealthValue = targetHealth.CurrentHealth;
            healthSlider.value = targetHealthValue;
        }

        private void Update()
        {
            if (!smoothTransition)
                return;

            healthSlider.value = Mathf.Lerp(
                healthSlider.value,
                targetHealthValue,
                smoothSpeed * Time.deltaTime
            );
        }

        private void OnHealthChanged(float currentHealth, float maxHealth)
        {
            targetHealthValue = currentHealth;

            if (!smoothTransition)
            {
                healthSlider.value = currentHealth;
            }
        }

        public void SetTarget(DragonHealth health)
        {
            if (targetHealth != null)
                targetHealth.OnHealthChanged -= OnHealthChanged;

            targetHealth = health;

            if (targetHealth == null)
                return;

            targetHealth.OnHealthChanged += OnHealthChanged;

            healthSlider.minValue = 0f;
            healthSlider.maxValue = targetHealth.MaxHealth;

            targetHealthValue = targetHealth.CurrentHealth;
            healthSlider.value = targetHealthValue;
        }

        private void OnDisable()
        {
            if (targetHealth != null)
                targetHealth.OnHealthChanged -= OnHealthChanged;
        }
    }
}