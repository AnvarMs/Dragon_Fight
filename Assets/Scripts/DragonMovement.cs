using UnityEngine;
using System.Collections;

namespace DragonFight
{
    public class DragonMovement : MonoBehaviour
    {
        [SerializeField] private DragonStats stats;
        [SerializeField] private DragonAnimator dragonAnimator;

        public Vector3 Velocity { get; private set; }
        public bool CanMove { get; set; } = true;

        private void Awake()
        {
            if (dragonAnimator == null)
                dragonAnimator = GetComponent<DragonAnimator>();
        }

        public void Move(Vector3 direction)
        {
            if (!CanMove || direction.sqrMagnitude < 0.001f)
            {
                Stop();
                return;
            }

            direction.y = 0f;
            direction.Normalize();

            float speed = stats != null ? stats.moveSpeed : 5f;
            Velocity = direction * speed;
            transform.position += Velocity * Time.deltaTime;

            RotateTowards(direction);
            dragonAnimator?.SetSpeed(1f);
        }

        public void Stop()
        {
            Velocity = Vector3.zero;
            dragonAnimator?.SetSpeed(0f);
        }

        public void RotateTowards(Vector3 direction)
        {
            direction.y = 0f;
            if (direction.sqrMagnitude < 0.001f) return;

            Quaternion target = Quaternion.LookRotation(direction);
            float speed = stats != null ? stats.rotationSpeed : 720f;

            transform.rotation = Quaternion.RotateTowards(
                transform.rotation, target, speed * Time.deltaTime);
        }

        public IEnumerator FaceTarget(Transform target)
        {
            if (target == null)
                yield break;

            Vector3 direction = target.position - transform.position;
            direction.y = 0f;

            if (direction.sqrMagnitude < 0.001f)
                yield break;

            while (true)
            {
                direction = target.position - transform.position;
                direction.y = 0f;

                if (direction.sqrMagnitude < 0.001f)
                    yield break;

                RotateTowards(direction);

                float angle = Vector3.Angle(
                    transform.forward,
                    direction.normalized
                );

                if (angle <= 2f)
                    break;

                yield return null;
            }
        }
    }
}
