using UnityEngine;
using TowerDefense.UI;

namespace TowerDefense.Core
{
    public class TowerManager : MonoBehaviour
    {
        [SerializeField] float currentEnergyValue = 500f;

        GameObject selectedTower = null;
        AudioSource audioSource;

        private void Awake()
        {
            audioSource = GetComponent<AudioSource>();
        }

        public void DecreaseEnergyValue(float cost)
        {
            currentEnergyValue -= cost;
            UpdateEnergyValueText();
        }

        public void IncreaseEnergyValue(float reward)
        {
            currentEnergyValue += reward;
            UpdateEnergyValueText();
        }

        public float GetEnergyValue()
        {
            return currentEnergyValue;
        }

        private void UpdateEnergyValueText()
        {
            FindObjectOfType<MainGameCanvasManager>().UpdateEnergyValueText(currentEnergyValue);
        }

        public void SetSelectedTower(GameObject tower)
        {
            selectedTower = tower;
        }

        public GameObject CheckSelectedTower()
        {
            return selectedTower;
        }

        public bool CheckCurrenEnergyValue()
        {
            return currentEnergyValue > selectedTower.GetComponent<Tower>().GetTowerCost();
        }

        public void BuildTower(Transform nodeTransform, GameObject nodeImage)
        {
            if (selectedTower!= null && selectedTower.GetComponent<Tower>().GetTowerCost() <= currentEnergyValue)
            {
                var newTower = Instantiate(selectedTower, nodeTransform.position, Quaternion.identity);
                newTower.transform.parent = nodeTransform;
                newTower.transform.rotation = nodeTransform.rotation;

                audioSource.Play();

                DecreaseEnergyValue(selectedTower.GetComponent<Tower>().GetTowerCost());
                UpdateEnergyValueText();

                nodeImage.SetActive(false);
                
                selectedTower = null;
            }
            else return;
        }
    }
}
