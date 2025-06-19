using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject[] obstaclePrefabs;
    public float obstacleSpawTime = 2f;
    public float obstacleSpeed = 1f;
    private float timeUntilObstacleSpawn;

    private void Update()
    {
        SpawLoop();
    }

    private void SpawLoop()
    {
        timeUntilObstacleSpawn += Time.deltaTime; // ✅ Perbaikan di sini
        if (timeUntilObstacleSpawn >= obstacleSpawTime)
        {
            Spawn();
            timeUntilObstacleSpawn = 0f;
        }
    }

    private void Spawn()
    {
        GameObject obstacleToSpawn = obstaclePrefabs[Random.Range(0, obstaclePrefabs.Length)]; // ✅ Perbaikan di sini
        GameObject spawnedObstacle = Instantiate(obstacleToSpawn, transform.position, Quaternion.identity);
        
        Rigidbody2D obstacleRB = spawnedObstacle.GetComponent<Rigidbody2D>(); // ✅ "2D" harus kapital
        if (obstacleRB != null)
        {
            obstacleRB.linearVelocity = Vector2.left * obstacleSpeed; // ✅ Kapitalisasi Vector2
        }
    }
}
