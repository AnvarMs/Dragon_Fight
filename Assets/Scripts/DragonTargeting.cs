using UnityEngine;

namespace DragonFight
{
    public class DragonTargeting : MonoBehaviour
    {
        [SerializeField] private Transform target;

        public Transform Target => target;

        public void SetTarget(Transform newTarget)
        {
            target = newTarget;
        }

        public bool HasTarget()
        {
            return target != null;
        }

        public float DistanceToTarget()
        {
            if (target == null) return float.MaxValue;

            Vector3 a = transform.position;
            Vector3 b = target.position;
            a.y = 0f;
            b.y = 0f;

            return Vector3.Distance(a, b);
        }
    }
}
