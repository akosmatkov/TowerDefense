using System.Collections;
using UnityEngine;

namespace TowerDefense.Core
{
    public class GameSession : MonoBehaviour
    {
        [SerializeField] GameObject menu = null;
        [SerializeField] GameObject loseMenu = null;
        [SerializeField] GameObject winMenu = null;

        private int numberOfEnemies = 0;

        AudioSource audioSouce;
        private void Awake()
        {
            Time.timeScale = 1;

            audioSouce = GetComponent<AudioSource>();

            numberOfEnemies = FindObjectOfType<WaveSpawner>().GetNumberOfEnemies();
        }

        public void ShowMenu()
        {
            Time.timeScale = 0;
            menu.SetActive(true);
        }

        public void ShowLoseMenu()
        {
            audioSouce.Stop();
            Time.timeScale = 0;
            loseMenu.SetActive(true);
        }

        public void Continue()
        {
            Time.timeScale = 1;
            menu.SetActive(false);
        }

        public void DecreaseNumberOfEnemies()
        {
            if(numberOfEnemies - 1 == 0)
            {
                StartCoroutine(ShowWinMenu());
            }
            numberOfEnemies--;
        }

        IEnumerator ShowWinMenu()
        {
            yield return new WaitForSeconds(3f);

            audioSouce.Stop();
            Time.timeScale = 0;

            if(winMenu != null)
            {
                winMenu.SetActive(true);
            }
        }
    }
}
