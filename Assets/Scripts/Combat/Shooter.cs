using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerDefense.Combat
{
    public class Shooter : MonoBehaviour
    {
        [SerializeField] Transform projectileSpawnPosition = null;
        [SerializeField] Projectile projectilePrefab = null;
        [SerializeField] float timeBetweenAttacks = 2f;
        [SerializeField] float attackTimer = 0f;

        private float currentDamageModifier = 0f;

        ShootSFXRandomizer sfxRandomizer;
        Transform currentTarget = null;
        AudioSource audioSource;

        private void Awake()
        {
            audioSource = GetComponent<AudioSource>();
            UpdateAttackTimer();
        }

        private void Start()
        {
            sfxRandomizer = GetComponentInParent<ShootSFXRandomizer>();
        }

        public void Shoot()
        {
            Projectile projectile = Instantiate(projectilePrefab, projectileSpawnPosition.position, Quaternion.identity);
            projectile.SetTarget(currentTarget);
            projectile.CalculateDamage(currentDamageModifier);

            if(sfxRandomizer != null)
            {
                audioSource.clip = sfxRandomizer.GetShootSFX();
            }
            audioSource.Play();

            attackTimer = 0f;
        }

        public void UpdateAttackTimer()
        {
            attackTimer += Time.deltaTime;
        }

        public void SetTarget(Transform target)
        {
            currentTarget = target;
        }

        public Transform GetTarget()
        {
            return currentTarget;
        }

        public bool CheckAttackTimer()
        {
            return attackTimer >= timeBetweenAttacks;
        }

        public void SetProjectileSpawnPosition(Transform spawnPosition)
        {
            projectileSpawnPosition = spawnPosition.transform;
        }

        public void SetDamageModifier(float damageModiier)
        {
            currentDamageModifier = damageModiier;
        }
    }
}
