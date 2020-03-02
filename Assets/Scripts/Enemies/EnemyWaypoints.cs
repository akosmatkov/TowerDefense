using UnityEngine;

namespace TowerDefense.Movement
{
    public class EnemyWaypoints : MonoBehaviour
    {
        [SerializeField] float waypointRadius = 0.3f;
        private void OnDrawGizmos()
        {
            for (int i = 0; i < transform.childCount - 1; i++)
            {
                int j = GetNextIndexOfWaypoint(i);

                Gizmos.DrawSphere(GetWaypoint(i), waypointRadius);
                Gizmos.DrawLine(GetWaypoint(i), GetWaypoint(j));
            }
        }

        public int GetNextIndexOfWaypoint(int i)
        {
            if (i < transform.childCount - 1)
            {
                return i + 1;
            }
            else return i;
        }

        public Vector3 GetWaypoint(int i)
        {
            return transform.GetChild(i).position;
        }

        public Vector3 GetLastWaypoint()
        {
            return transform.GetChild(transform.childCount - 1).position;
        }
    }
}
