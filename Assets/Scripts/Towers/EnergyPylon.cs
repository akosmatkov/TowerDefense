using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TowerDefense.UI;

namespace TowerDefense.Core
{
    public class EnergyPylon : MonoBehaviour
    {
        [SerializeField] float timeBetweenEnergySpawns = 30f;
        [SerializeField] EnergyTextSpawner energyTextSpawner = null;

        Tower tower;
        TowerManager towerManager;

        private void Awake()
        {
            tower = GetComponent<Tower>();
            towerManager = FindObjectOfType<TowerManager>();
        }

        private void Start()
        {
            StartCoroutine(SpawnEnergy());
        }

        IEnumerator SpawnEnergy()
        {
            yield return new WaitForSeconds(timeBetweenEnergySpawns);
            towerManager.IncreaseMoneyValue(tower.GetPylonEnergy());

            energyTextSpawner.SpawnEnergyText(tower.GetPylonEnergy());

            StartCoroutine(SpawnEnergy());
        }
    }
}
