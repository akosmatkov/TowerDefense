using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerDefense.UI
{
    public class EnergyTextSpawner : MonoBehaviour
    {
        [SerializeField] EnergyText energyText = null;

        public void SpawnEnergyText(float energyAmount)
        {
            EnergyText instance = Instantiate(energyText, transform.position, Quaternion.identity);
            instance.SetEnergyText(energyAmount);

            Destroy(instance.gameObject, 3f);
        }
    }
}
