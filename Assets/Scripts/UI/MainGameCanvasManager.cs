using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TowerDefense.Core;
using UnityEngine.UI;

namespace TowerDefense.UI
{
    public class MainGameCanvasManager : MonoBehaviour
    {
        [SerializeField] Text moneyValueText = null;

        TowerManager towerManager;

        private void Awake()
        {
            towerManager = FindObjectOfType<TowerManager>();
        }

        void Start()
        {
            moneyValueText.text = towerManager.GetMoneyValue().ToString();
        }

        public void UpdateMoneyValueText(float valueText)
        {
            moneyValueText.text = valueText.ToString();
        }
    }
}
