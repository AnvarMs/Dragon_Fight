using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace DragonFight
{
    public class AbilityCooldownUI : MonoBehaviour
    {
        public enum AbilityType
        {
            Basic,
            Fire,
            Fly
        }

        [SerializeField] private DragonCombat combat;
        [SerializeField] private AbilityType abilityType;

        [Header("UI")]
        [SerializeField] private Image cooldownFill;
        [SerializeField] private TMP_Text cooldownText;

        [Header("Options")]
        [SerializeField] private bool showCooldownText = true;

        private void Update()
        {
            if (combat == null)
                return;

            float remaining = 0f;
            float duration = 0f;

            switch (abilityType)
            {
                case AbilityType.Basic:
                    remaining = combat.BasicCooldownRemaining;
                    duration = combat.BasicCooldownDuration;
                    break;

                case AbilityType.Fire:
                    remaining = combat.FireCooldownRemaining;
                    duration = combat.FireCooldownDuration;
                    break;

                case AbilityType.Fly:
                    // Fly will be connected when its cooldown
                    // is added to DragonCombat.
                    remaining = 0f;
                    duration = 0f;
                    break;
            }

            UpdateUI(remaining, duration);
        }

        private void UpdateUI(float remaining, float duration)
        {
            bool onCooldown = remaining > 0f;

            if (cooldownFill != null)
            {
                if (duration > 0f)
                {
                    cooldownFill.fillAmount =
                        Mathf.Clamp01(remaining / duration);
                }
                else
                {
                    cooldownFill.fillAmount = 0f;
                }
            }

            if (cooldownText != null)
            {
                if (showCooldownText && onCooldown)
                {
                    cooldownText.text = remaining.ToString("0.0");
                    cooldownText.gameObject.SetActive(true);
                }
                else
                {
                    cooldownText.gameObject.SetActive(false);
                }
            }
        }

        public void SetCombat(DragonCombat dragonCombat)
        {
            combat = dragonCombat;
        }
    }
}