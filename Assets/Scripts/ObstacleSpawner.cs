using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject[] obstaclePrefabs;   // Array de prefabs de obstáculos y enemigos
    public float spawnRate = 2f;           // Tiempo entre cada aparición
    public float minY = -2f;               // Mínima posición Y en la que puede aparecer un obstáculo
    public float maxY = 2f;                // Máxima posición Y en la que puede aparecer un obstáculo
    public float spawnXPosition = 10f;     // Posición X en la que los obstáculos aparecerán
    private float timer = 0f;              // Temporizador interno

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnRate)
        {
            SpawnObstacle();
            timer = 0f;
        }
    }

    void SpawnObstacle()
    {
        if (obstaclePrefabs != null && obstaclePrefabs.Length > 0)
        {
            int randomIndex = Random.Range(0, obstaclePrefabs.Length);
            GameObject obstacle = obstaclePrefabs[randomIndex];

            if (obstacle != null)
            {
                float randomY = Random.Range(minY, maxY);
                Vector2 spawnPosition = new Vector2(spawnXPosition, randomY);

                GameObject newObstacle = Instantiate(obstacle, spawnPosition, Quaternion.identity);
                // Añadir el script de destrucción solo a los clones
                newObstacle.AddComponent<DestroyAfterLeavingScreen>();
            }
            else
            {
                Debug.LogWarning("Obstacle prefab at index " + randomIndex + " is null!");
            }
        }
        else
        {
            Debug.LogWarning("No valid prefabs found in the array!");
        }
    }

}