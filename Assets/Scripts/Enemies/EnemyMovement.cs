using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerDefense.Movement
{
    public class EnemyMovement : MonoBehaviour
    {
        EnemyWaypoints waypoints = null;

        private float waypointTolerance = 1f;
        private int currentWaypointIndex = 0;

        public void SetWaypointsPrefab(EnemyWaypoints waypointsPrefab)
        {
            waypoints = waypointsPrefab;
        }

        public bool AtWaypoint()
        {
            float distanceToWaypoint = Vector3.Distance(transform.position, GetCurrentWaypoint());
            return distanceToWaypoint < waypointTolerance;
        }

        public Vector3 GetCurrentWaypoint()
        {
            return waypoints.GetWaypoint(currentWaypointIndex);
        }

        public Vector3 GetLastWaypoint()
        {
            Vector3 lastWaypoint = waypoints.GetLastWaypoint();
            return lastWaypoint;
        }

        public float GetWaypointTolerance()
        {
            return waypointTolerance;
        }

        public void CycleWaypoint()
        {
            currentWaypointIndex = waypoints.GetNextIndexOfWaypoint(currentWaypointIndex);
        }
    }
}
