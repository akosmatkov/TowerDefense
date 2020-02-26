using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TowerDefense.AI;
using UnityEngine.UI;

namespace TowerDefense.Core
{
    public class Health : MonoBehaviour
    {
        [SerializeField] float maxHealth = 500f;
        [SerializeField] bool isDead = false;
        [SerializeField] AudioClip deathSfx = null;
        [SerializeField] GameObject deathVfx = null;
        [SerializeField] Slider healthBarSlider = null;
        [SerializeField] float destructionDelay = 1.5f;
        [SerializeField] float moneyReward = 20f;

        private float currentHealth = 0;

        Animator animator;
        AudioSource audioSource;
        GameSession gameSession;
        EnemyAI enemyAI;

        private void Awake()
        {
            audioSource = GetComponent<AudioSource>();
            gameSession = FindObjectOfType<GameSession>();
            animator = GetComponent<Animator>();
            enemyAI = GetComponent<EnemyAI>();

            currentHealth = maxHealth;
            UpdateHealthBarSlider();
        }

        public void GetDamage(float damage)
        {
            if (!isDead)
            {
                if (currentHealth > 0)
                {
                    currentHealth -= damage;

                    UpdateHealthBarSlider();
                }
                if (currentHealth <= 0)
                {
                    if (gameObject.tag == "PlayerBase")
                    {
                        gameSession.ShowLoseMenu();
                    }
                    else
                    {
                        StartCoroutine(Die());
                    }
                }
            }
        }

        IEnumerator Die()
        {
            if(!isDead)
            {
                gameSession.DecreaseNumberOfEnemies();

                var towers = FindObjectsOfType<TowerAI>();
                foreach (var tower in towers)
                {
                    tower.RemoveFromTargetList(this.transform);
                }
            }
            isDead = true;        

            FindObjectOfType<TowerManager>().IncreaseMoneyValue(moneyReward);

            if (enemyAI != null)
            {
                enemyAI.StopMovement();
            }

            if (deathSfx != null)
            {
                audioSource.clip = deathSfx;
                audioSource.Play();
            }
            if(deathVfx != null)
            {
                Instantiate(deathVfx, transform.position, Quaternion.identity);
            }

            healthBarSlider.transform.parent.gameObject.SetActive(false);
            animator.SetTrigger("isDead");

            yield return new WaitForSeconds(destructionDelay);

            Destroy(gameObject);
        }

        public bool IsDead()
        {
            return isDead;
        }

        private void UpdateHealthBarSlider()
        {
            if (healthBarSlider == null) return;
            healthBarSlider.value = currentHealth / maxHealth;
        }
    }
}
