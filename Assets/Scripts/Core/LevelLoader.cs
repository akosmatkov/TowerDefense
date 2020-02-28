using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace TowerDefense.Core
{
    public class LevelLoader : MonoBehaviour
    {
        [SerializeField] GameObject levelLoadAnimator = null;

        Animator animator;

        private void Awake()
        {
            animator = levelLoadAnimator.GetComponent<Animator>();
        }

        public void RestartLevel()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            Time.timeScale = 1;
        }

        public void LoadNextLevel()
        {
            StartCoroutine(LoadLevel());
        }

        IEnumerator LoadLevel()
        {
            if(animator != null)
            {
                animator.SetTrigger("loadLevel");
            }
            var asyncLoadLevel = SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1, LoadSceneMode.Single);
            
            yield return asyncLoadLevel.isDone;

            animator.SetTrigger("isLoaded");
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
