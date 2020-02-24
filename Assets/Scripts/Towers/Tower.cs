using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TowerDefense.Combat;
using TowerDefense.UI;
using UnityEngine.UI;

namespace TowerDefense.Core
{
    public class Tower : MonoBehaviour
    {
        [SerializeField] float towerCost = 50f;
        [SerializeField] bool isCombatTower = true;
        [SerializeField] GameObject currentTowerPrefab = null;
        [SerializeField] TowerLevelConfig[] towerLevelConfigs = null;
        [SerializeField] Canvas towerUICanvas = null;
        [SerializeField] Text upgradeCostText = null;
        [SerializeField] GameObject towerUpgradeVfx = null;

        private int currentTowerLevel = 0;

        TowerManager towerManager;
        GameObject currentTower = null;

        private void Awake()
        {
            towerManager = FindObjectOfType<TowerManager>();
            upgradeCostText.text = towerLevelConfigs[currentTowerLevel].GetTowerUpgradeCost().ToString();

            PlaceTower(currentTowerLevel);
        }

        private void Start()
        {
            towerUICanvas.gameObject.SetActive(false);

            if (CheckShooterComponent())
            {
                currentTower.GetComponent<Shooter>().SetDamageModifier(towerLevelConfigs[currentTowerLevel].GetDamageModifier());
            }
        }

        public float GetPylonEnergy()
        {
            return towerLevelConfigs[currentTowerLevel].GetPylonEnergyToSpawn();
        }

        private void OnMouseUp()
        {
            if (currentTowerLevel == towerLevelConfigs.Length - 1) return;
            towerUICanvas.gameObject.SetActive(true);
        }

        public void UpgradeTower()
        {
            currentTowerLevel++;

            Destroy(currentTower);

            PlaceTower(currentTowerLevel);
            Instantiate(towerUpgradeVfx, transform.position, Quaternion.identity);

            towerManager.DecreaseMoneyValue(towerLevelConfigs[currentTowerLevel - 1].GetTowerUpgradeCost());
            upgradeCostText.text = towerLevelConfigs[currentTowerLevel].GetTowerUpgradeCost().ToString();

            if (CheckShooterComponent())
            {
                currentTower.GetComponent<Shooter>().SetDamageModifier(towerLevelConfigs[currentTowerLevel].GetDamageModifier());
            }

            towerUICanvas.GetComponent<UIDeactivator>().SetIsPointerEnter();
            towerUICanvas.gameObject.SetActive(false);


        }

        private void PlaceTower(int level)
        {
            currentTowerPrefab = towerLevelConfigs[level].GetTowerPrefab();
            currentTower = Instantiate(currentTowerPrefab, transform.position, transform.rotation);
            currentTower.transform.parent = transform;
        }

        public void CheckTowerUpgradeCost()
        {
            if(towerLevelConfigs[currentTowerLevel].GetTowerUpgradeCost() <= towerManager.GetMoneyValue())
            {
                UpgradeTower();
            }
        }

        public float GetTowerCost()
        {
            return towerCost;
        }

        public bool GetTowerType()
        {
            return isCombatTower;
        }

        private bool CheckShooterComponent()
        {
            return currentTower.GetComponent<Shooter>();
        }
    }
}
