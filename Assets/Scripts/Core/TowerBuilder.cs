using UnityEngine;

namespace TowerDefense.Core
{
    public class TowerBuilder : MonoBehaviour
    {
        [SerializeField] bool nodeForCombatTower = true;
        [SerializeField] GameObject surfaceImage = null;
        private bool isBuilded = false;

        TowerManager towerManager;

        private void Awake()
        {
            towerManager = FindObjectOfType<TowerManager>();
        }

        private void OnMouseUp()
        {
            if (!isBuilded)
            {
                if (towerManager.CheckSelectedTower() != null)
                {
                    if (nodeForCombatTower == false && !towerManager.CheckSelectedTower().GetComponent<Tower>().GetTowerType())
                    {
                        BuildTower();
                    }
                    else if (nodeForCombatTower && towerManager.CheckSelectedTower().GetComponent<Tower>().GetTowerType())
                    {
                        BuildTower();
                    }
                }
            }
            else return;
        }

        private void BuildTower()
        {
            towerManager.BuildTower(transform, surfaceImage);
            isBuilded = true;
        }
    }
}
