using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TowerDefense.Movement;

namespace TowerDefense.Core
{
    public class WaveSpawner : MonoBehaviour
    {
        [SerializeField] WaveConfig[] waves = null;
        [SerializeField] float timeBetweenWavesSpawn = 10f;

        void Start()
        {
            StartCoroutine(SpawnWave());
        }

        IEnumerator SpawnWave()
        {
            foreach (WaveConfig waveConfig in waves)
            {
                for (int i = 0; i < waveConfig.GetNumberOfEnemies(); i++)
                {
                    GameObject enemy = Instantiate(waveConfig.GetEnemyPrefab(), transform.position, Quaternion.identity);
                    enemy.GetComponent<EnemyMovement>().SetWaypointsPrefab(waveConfig.GetWaypointsPrefab());

                    yield return new WaitForSeconds(waveConfig.GetTimeBetweenSpawns());
                }
                yield return new WaitForSeconds(timeBetweenWavesSpawn);
            }
        }

        public int GetNumberOfEnemies()
        {
            int numberOfEnemies = 0;
            foreach (WaveConfig waveConfig in waves)
            {
                numberOfEnemies += waveConfig.GetNumberOfEnemies();
            }

            return numberOfEnemies;
        }
    }

}