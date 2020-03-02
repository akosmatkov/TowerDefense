using UnityEngine;

namespace TowerDefense.Combat
{
    public class TowerHead : MonoBehaviour
    {
        [SerializeField] Transform projectileSpawnPosition = null;

        private void Start()
        {
            GetComponentInParent<Shooter>().SetProjectileSpawnPosition(projectileSpawnPosition);
        }
    }
}
