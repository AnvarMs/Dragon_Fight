using UnityEngine;
using UnityEngine.InputSystem;

namespace DragonFight
{
    public class PlayerDragonInput : MonoBehaviour
    {
        public Vector2 MoveInput { get; private set; }
        public bool BasicAttackPressed { get; private set; }
        public bool FireAttackPressed { get; private set; }

        private void Update()
        {
            MoveInput = Vector2.zero;
            BasicAttackPressed = false;
            FireAttackPressed = false;

            Keyboard keyboard = Keyboard.current;
            if (keyboard == null) return;

            float x = 0f;
            float y = 0f;

            if (keyboard.aKey.isPressed || keyboard.leftArrowKey.isPressed) x -= 1f;
            if (keyboard.dKey.isPressed || keyboard.rightArrowKey.isPressed) x += 1f;
            if (keyboard.sKey.isPressed || keyboard.downArrowKey.isPressed) y -= 1f;
            if (keyboard.wKey.isPressed || keyboard.upArrowKey.isPressed) y += 1f;

            MoveInput = new Vector2(x, y).normalized;

            BasicAttackPressed =
                keyboard.digit1Key.wasPressedThisFrame ||
                keyboard.zKey.wasPressedThisFrame;

            FireAttackPressed =
                keyboard.digit2Key.wasPressedThisFrame ||
                keyboard.xKey.wasPressedThisFrame;
        }
    }
}
