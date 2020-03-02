using UnityEngine;
using UnityEngine.SceneManagement;

namespace TowerDefense.Core
{
    public class LevelLoader : MonoBehaviour
    {
        public void RestartLevel()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            Time.timeScale = 1;
        }

        public void LoadNextLevel()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

        public void LoadMainMenu()
        {
            SceneManager.LoadScene("Main Menu");
        }

        public void Quit()
        {
            Application.Quit();
        }
    }
}
