using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public List<GameObject> enemies;
    Vector2 spawnPoint;
    public float spawnRate = 5f;
    float nextSpawn = 0.0f;
    public float nextSpawnerActivation = 0.0f;
    float timeElapsed;

    // Start is called before the first frame update
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        timeElapsed = Time.timeSinceLevelLoad;
        if (timeElapsed > nextSpawnerActivation)
        {
            if (timeElapsed > nextSpawn)
            {
                nextSpawn = timeElapsed + spawnRate;
                spawnPoint = new Vector2(transform.position.x, transform.position.y);
                Instantiate(enemies[Random.Range(0,enemies.Count)], spawnPoint, Quaternion.identity);
                if (spawnRate > 1)
                {
                    spawnRate = spawnRate - 0.05f;
                }
                else
                {
                    spawnRate = 1;
                }
            }
        }
    }
}
