using UnityEngine;
using TowerDefense.Core;

namespace TowerDefense.Combat
{
    public class Projectile : MonoBehaviour
    {
        [SerializeField] GameObject explosionVfx = null;
        [SerializeField] GameObject spawnVfx = null;
        [SerializeField] AudioClip explosionSfx = null;
        [SerializeField] float projectileSpeed = 3f;
        [SerializeField] float projectileDamage = 10f;

        private float calculatedDamage = 0;

        Transform target;

        private void Awake()
        {
            calculatedDamage = projectileDamage;
        }

        private void Start()
        {
            if (spawnVfx != null)
            {
                Instantiate(spawnVfx, transform.position, Quaternion.identity);
            }
            Destroy(gameObject, 4f);
        }

        void Update()
        {
            MoveToTarget();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag != "Player" && other.gameObject.tag != "Node")
            {
                if (other.GetComponent<Health>() != null)
                {
                    other.GetComponent<Health>().GetDamage(calculatedDamage);
                }
                Explode();
            }
        }

        private void Explode()
        {
            if (explosionSfx != null)
            {
                AudioSource.PlayClipAtPoint(explosionSfx, Camera.main.transform.position);
            }
            if (explosionVfx != null)
            {
                Instantiate(explosionVfx, transform.position, Quaternion.identity);
            }
            Destroy(gameObject);
        }

        public void SetTarget(Transform targetToShoot)
        {
            target = targetToShoot;
        }

        private void MoveToTarget()
        {
            transform.LookAt(target);

            if (target != null)
            {
                transform.position = Vector3.MoveTowards(transform.position, target.transform.position, projectileSpeed * Time.deltaTime);
            }
            else
                Explode();
        }

        public void CalculateDamage(float damageModifier)
        {
            calculatedDamage = projectileDamage + damageModifier;
        }
    }
}
