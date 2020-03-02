using UnityEngine;

namespace TowerDefense.UI
{
    public class CameraFacing : MonoBehaviour
    {
        void Update()
        {
            transform.forward = Camera.main.transform.forward;
        }
    }
}
