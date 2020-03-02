using UnityEngine;
using TowerDefense.Core;
using UnityEngine.UI;

namespace TowerDefense.UI
{
    public class MainGameCanvasManager : MonoBehaviour
    {
        [SerializeField] Text energyValueText = null;

        TowerManager towerManager;

        private void Awake()
        {
            towerManager = FindObjectOfType<TowerManager>();
        }

        void Start()
        {
            energyValueText.text = towerManager.GetEnergyValue().ToString();
        }

        public void UpdateEnergyValueText(float valueText)
        {
            energyValueText.text = valueText.ToString();
        }
    }
}
