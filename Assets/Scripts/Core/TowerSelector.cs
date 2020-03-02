using UnityEngine;
using UnityEngine.UI;

namespace TowerDefense.Core
{
    public class TowerSelector : MonoBehaviour
    {
        [SerializeField] GameObject towerToBuild = null;
        [SerializeField] Text towerCostText = null;

        TowerManager towerManager;

        private void Awake()
        {
            towerManager = FindObjectOfType<TowerManager>();
        }

        void Start()
        {
            towerCostText.text = towerToBuild.GetComponent<Tower>().GetTowerCost().ToString();
        }

        public void SelectTower()
        {
            towerManager.SetSelectedTower(towerToBuild);
        }
    }
}
