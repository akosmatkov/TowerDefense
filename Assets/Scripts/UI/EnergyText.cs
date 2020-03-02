using UnityEngine;
using UnityEngine.UI;

namespace TowerDefense.UI
{
    public class EnergyText : MonoBehaviour
    {
        [SerializeField] Text energyText = null;

        public void SetEnergyText(float energyAmount)
        {
            energyText.text = energyAmount.ToString();
        }
    }
}
