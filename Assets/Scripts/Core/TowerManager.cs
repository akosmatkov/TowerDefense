using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TowerDefense.UI;

namespace TowerDefense.Core
{
    public class TowerManager : MonoBehaviour
    {
        [SerializeField] float currentMoneyValue = 500f;

        GameObject selectedTower = null;
        AudioSource audioSource;

        private void Awake()
        {
            audioSource = GetComponent<AudioSource>();
        }

        public void DecreaseMoneyValue(float cost)
        {
            currentMoneyValue -= cost;
            UpdateMoneyValueText();
        }

        public void IncreaseMoneyValue(float reward)
        {
            currentMoneyValue += reward;
            UpdateMoneyValueText();
        }

        public float GetMoneyValue()
        {
            return currentMoneyValue;
        }

        private void UpdateMoneyValueText()
        {
            FindObjectOfType<MainGameCanvasManager>().UpdateMoneyValueText(currentMoneyValue);
        }

        public void SetSelectedTower(GameObject tower)
        {
            selectedTower = tower;
        }

        public GameObject CheckSelectedTower()
        {
            return selectedTower;
        }

        public bool CheckCurrenMoneyValue()
        {
            return currentMoneyValue > selectedTower.GetComponent<Tower>().GetTowerCost();
        }

        public void BuildTower(Transform nodeTransform, GameObject nodeImage)
        {
            if (selectedTower!= null && selectedTower.GetComponent<Tower>().GetTowerCost() <= currentMoneyValue)
            {
                var newTower = Instantiate(selectedTower, nodeTransform.position, Quaternion.identity);
                newTower.transform.parent = nodeTransform;
                newTower.transform.rotation = nodeTransform.rotation;

                audioSource.Play();

                DecreaseMoneyValue(selectedTower.GetComponent<Tower>().GetTowerCost());
                UpdateMoneyValueText();

                nodeImage.SetActive(false);
                
                selectedTower = null;
            }
            else return;
        }
    }
}
