using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerDefense.Core
{
    public class GameSession : MonoBehaviour
    {
        [SerializeField] GameObject menu = null;
        [SerializeField] GameObject loseMenu = null;

        public void ShowMenu()
        {
            Time.timeScale = 0;
            menu.SetActive(true);
        }

        public void ShowLoseMenu()
        {
            Time.timeScale = 0;
            loseMenu.SetActive(true);
        }

        public void Continue()
        {
            Time.timeScale = 1;
            menu.SetActive(false);
        }
    }
}
