using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    public GameObject enemyPrefab; // The enemy prefab to spawn
    public int numberOfEnemies = 5; // The number of enemies to spawn
    public float minX = -45f; // Minimum X-axis position
    public float maxX = 45f; // Maximum X-axis position
    public float minZ = 30f; // Minimum Z-axis position
    public float maxZ = 105f; // Maximum Z-axis position

    private void Start()
    {
        // Spawn the specified number of enemies
        for (int i = 0; i < numberOfEnemies; i++)
        {
            SpawnEnemyAtRandomPosition();
        }
    }

    private void SpawnEnemyAtRandomPosition()
    {
        // Generate random positions within the specified range
        float randomX = Random.Range(minX, maxX);
        float randomZ = Random.Range(minZ, maxZ);

        // Create a new enemy instance at the random position
        Vector3 spawnPosition = new Vector3(randomX, 0f, randomZ);
        Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
    }
}
