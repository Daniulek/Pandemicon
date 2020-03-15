using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Enemy Spawn Config")]
public class SpawnConfig : ScriptableObject
{
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] GameObject pathPrefab;
    [SerializeField] GameObject enemyBulletPrefab;
    [SerializeField] Transform motherCellTrans;
    [SerializeField] float timeBetweenSpawns = 0.5f;
    [SerializeField] float spawnRandomFactor = 0.3f;
    [SerializeField] float moveSpeed = 2f;
    
    

    public GameObject GetEnemyPrefab() { return enemyPrefab; }

    public Transform GetMotherCellTrans() { return motherCellTrans; }

    public GameObject GetEnemyBulletPrefab() { return enemyBulletPrefab; }

    public List<Transform> GetWaypoints()
    {
        var spawnWaypoints = new List<Transform>();
        foreach (Transform child in pathPrefab.transform)
        {
            spawnWaypoints.Add(child);
        }
        return spawnWaypoints;
    }

    public float GetTimeBetweenSpawns() { return timeBetweenSpawns; }

    public float GetSpawnRandomFactor() { return spawnRandomFactor; }


    public float GetMoveSpeed() { return moveSpeed; }
}
