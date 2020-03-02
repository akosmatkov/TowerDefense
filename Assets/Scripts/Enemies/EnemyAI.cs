using UnityEngine;
using UnityEngine.AI;
using TowerDefense.Combat;
using TowerDefense.Movement;
using TowerDefense.Core;

namespace TowerDefense.AI
{
    public class EnemyAI : MonoBehaviour
    {
        [SerializeField] GameObject enemyTurret = null;
        [SerializeField] bool atLastWaypoint = false;

        Shooter shooter;
        EnemyMovement enemyMovement;
        NavMeshAgent navMeshAgent;

        private void Awake()
        {
            shooter = GetComponent<Shooter>();
            enemyMovement = GetComponent<EnemyMovement>();
            navMeshAgent = GetComponent<NavMeshAgent>();
        }

        private void Update()
        {
            MoveBehaviour();
            AttackBehaviour();
        }

        private void AttackBehaviour()
        {
            if (atLastWaypoint)
            {
                if (shooter.GetTarget() == null)
                {
                    shooter.SetTarget(GameObject.FindWithTag("PlayerBase").transform);
                }
                if (enemyTurret != null)
                {
                    enemyTurret.transform.LookAt(shooter.GetTarget());
                }
                if (shooter.CheckAttackTimer() && !shooter.GetTarget().GetComponent<Health>().IsDead())
                {
                    shooter.Shoot();
                }
                shooter.UpdateAttackTimer();
            }
        }

        private void MoveBehaviour()
        {
            navMeshAgent.destination = enemyMovement.GetCurrentWaypoint();

            if (enemyMovement.AtWaypoint())
            {
                if (Vector3.Distance(transform.position, enemyMovement.GetLastWaypoint()) < enemyMovement.GetWaypointTolerance())
                {
                    AtLastWaypoint();
                }
                else
                {
                    enemyMovement.CycleWaypoint();
                }
            }
        }

        public void AtLastWaypoint()
        {
            atLastWaypoint = true;
        }

        public void StopMovement()
        {
            navMeshAgent.speed = 0;
        }
    }
}
