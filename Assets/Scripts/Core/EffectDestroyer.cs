using UnityEngine;

namespace TowerDefense.Core
{
    public class EffectDestroyer : MonoBehaviour
    {
        private void Update()
        {
            if (!GetComponent<ParticleSystem>().IsAlive())
            {
                Destroy(gameObject);
            }
        }
    }
}
