using UnityEngine;

namespace DragonFight
{
    public class BattleGameManager : MonoBehaviour
    {
        [SerializeField] private DragonController playerDragon;
        [SerializeField] private DragonController aiDragon;
        [SerializeField] private Transform playerSpawn;
        [SerializeField] private Transform aiSpawn;

        private bool battleEnded;

        private void Start()
        {
            if (playerDragon == null || aiDragon == null)
            {
                Debug.LogError("Assign both dragons to BattleGameManager.");
                return;
            }

            playerDragon.SetTarget(aiDragon.transform);
            aiDragon.SetTarget(playerDragon.transform);

            playerDragon.Health.OnDeath += OnDragonDeath;
            aiDragon.Health.OnDeath += OnDragonDeath;

            if (playerSpawn != null)
                playerDragon.transform.SetPositionAndRotation(
                    playerSpawn.position, playerSpawn.rotation);

            if (aiSpawn != null)
                aiDragon.transform.SetPositionAndRotation(
                    aiSpawn.position, aiSpawn.rotation);
        }

        private void OnDestroy()
        {
            if (playerDragon != null)
                playerDragon.Health.OnDeath -= OnDragonDeath;

            if (aiDragon != null)
                aiDragon.Health.OnDeath -= OnDragonDeath;
        }

        private void OnDragonDeath(DragonHealth deadDragon)
        {
            if (battleEnded) return;
            battleEnded = true;

            Debug.Log(
                deadDragon == playerDragon.Health
                    ? "AI WINS"
                    : "PLAYER WINS");
        }
    }
}
