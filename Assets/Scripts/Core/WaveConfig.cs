using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TowerDefense.Movement;

[CreateAssetMenu(fileName = "WaveConfig", menuName = "Wave/Create New Wave", order = 0)]
public class WaveConfig : ScriptableObject
{
    [SerializeField] GameObject enemyPrefab = null;
    [SerializeField] EnemyWaypoints waypointsPrefab = null;
    [SerializeField] float timeBetweenSpawns = 2f;
    [SerializeField] int numberOfEnemies = 5;

    public GameObject GetEnemyPrefab()
    {
        return enemyPrefab;
    }

    public EnemyWaypoints GetWaypointsPrefab()
    {
        return waypointsPrefab;
    }

    public float GetTimeBetweenSpawns()
    {
        return timeBetweenSpawns;
    }

    public int GetNumberOfEnemies()
    {
        return numberOfEnemies;
    }
}
