using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject[] obstaclePrefabs;
    public float obstacleSpawTime = 5f;
    private float minSpawnTime = 2.5f;
    private float spawnDecreaseRate = 1f;
    public float obstacleSpeed = 7f;
    private float timeUntilObstacleSpawn;
    [SerializeField] private PlayerMovement playerMovement;
    private float elapsedTime = 0f;

    private void Update()
    {
        elapsedTime += Time.deltaTime;
        UpdateDifficulty();
        SpawLoop();
    }

    private void SpawLoop()
    {
        timeUntilObstacleSpawn += Time.deltaTime;
        if (timeUntilObstacleSpawn >= obstacleSpawTime)
        {
            Spawn();
            timeUntilObstacleSpawn = 0f;
        }
    }

    private void Spawn()
    {
        GameObject obstacleToSpawn = obstaclePrefabs[Random.Range(0, obstaclePrefabs.Length)];
        GameObject spawnedObstacle = Instantiate(obstacleToSpawn, transform.position, Quaternion.identity);
        
        Rigidbody2D obstacleRB = spawnedObstacle.GetComponent<Rigidbody2D>();
        if (obstacleRB != null)
        {
            obstacleRB.velocity = Vector2.left * obstacleSpeed;
        }
    }

    private void UpdateDifficulty()
    {
        float speedIncrease = elapsedTime / 15f;

        obstacleSpeed = 7f + speedIncrease;
        playerMovement.moveSpeed = 3f + speedIncrease * 0.5f;
        obstacleSpawTime = Mathf.Max(minSpawnTime, 5f - (elapsedTime / 10f) * spawnDecreaseRate);
    }
}
