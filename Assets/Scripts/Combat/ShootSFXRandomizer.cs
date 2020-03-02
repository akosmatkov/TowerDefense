using UnityEngine;

namespace TowerDefense.Combat
{
    public class ShootSFXRandomizer : MonoBehaviour
    {
        [SerializeField] AudioClip[] shootSfx = null;

        private int GetRndomIndex()
        {
            return Random.Range(0, shootSfx.Length);
        }

        public AudioClip GetShootSFX()
        {
            return shootSfx[GetRndomIndex()];
        }
    }
}
