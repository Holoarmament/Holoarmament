using UnityEngine;

public class SpawnEnemy1 : MonoBehaviour
{
    public GameObject enemyPrefab; // The enemy prefab to spawn
    public float minX = -45f; // Minimum X-axis position
    public float maxX = 45f; // Maximum X-axis position
    public float minZ = 30f; // Minimum Z-axis position
    public float maxZ = 105f; // Maximum Z-axis position
    public float spawnInterval = 5.0f; // Time interval between spawns
    public float enemyLifetime = 5.0f; // Lifetime of each enemy

    private float nextSpawnTime;

    private void Start()
    {
        // Set the initial spawn time
        nextSpawnTime = Time.time + spawnInterval;

        // Spawn the first enemy
        SpawnEnemyAtRandomPosition();
    }

    private void Update()
    {
        // Check if it's time to spawn a new enemy
        if (Time.time >= nextSpawnTime)
        {
            // Spawn a new enemy
            SpawnEnemyAtRandomPosition();

            // Update the next spawn time
            nextSpawnTime = Time.time + spawnInterval;
        }
    }

    private void SpawnEnemyAtRandomPosition()
    {
        // Generate random positions within the specified range
        float randomX = Random.Range(minX, maxX);
        float randomZ = Random.Range(minZ, maxZ);

        // Create a new enemy instance at the random position
        Vector3 spawnPosition = new Vector3(randomX, 0f, randomZ);
        GameObject newEnemy = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);

        // Schedule the enemy to despawn after a specified lifetime
        Destroy(newEnemy, enemyLifetime);
    }
}
