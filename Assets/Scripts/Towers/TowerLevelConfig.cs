using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TowerLevelConfig", menuName = "TowerLevelConfig/CreateNewConfig", order = 0)]
public class TowerLevelConfig : ScriptableObject
{
    [SerializeField] GameObject towerPrefab = null;
    [SerializeField] float towerUpgradeCost = 0;
    [SerializeField] float damageModifier = 20f;
    [SerializeField] float pylonEnergyToSpawn = 10f;

    public GameObject GetTowerPrefab()
    {
        return towerPrefab;
    }

    public float GetTowerUpgradeCost()
    {
        return towerUpgradeCost;
    }

    public float GetDamageModifier()
    {
        return damageModifier;
    }

    public float GetPylonEnergyToSpawn()
    {
        return pylonEnergyToSpawn;
    }
}
