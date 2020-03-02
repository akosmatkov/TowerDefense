using System.Collections.Generic;
using UnityEngine;
using TowerDefense.Combat;
using TowerDefense.Core;

namespace TowerDefense.AI
{
    public class TowerAI : MonoBehaviour
    {
        List<Transform> targets = new List<Transform>();

        Shooter shooter;
        Animator animator;

        private void Awake()
        {
            shooter = GetComponent<Shooter>();
            animator = GetComponent<Animator>();
        }

        private void Update()
        {
            if(targets.Count == 0)
            {
                animator.enabled = true;
            }
            AttackBehaviour();
        }

        private void AttackBehaviour()
        {
            if(shooter.GetTarget() == null)
            {
                if(targets.Count > 0)
                {
                    shooter.SetTarget(targets[0]);
                }
            }
            if (shooter.GetTarget() != null)
            {
                if(shooter.GetTarget().GetComponent<Health>().IsDead())
                {
                    targets.Remove(shooter.GetTarget());
                    if (targets.Count != 0)
                    {
                        shooter.SetTarget(targets[0]);
                    }
                }

                transform.GetComponentInChildren<TowerHead>().transform.LookAt(shooter.GetTarget());

                if (shooter.CheckAttackTimer() && !shooter.GetTarget().GetComponent<Health>().IsDead())
                {
                    shooter.Shoot();
                }
                shooter.UpdateAttackTimer();
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag == "Enemy" && !targets.Contains(other.gameObject.transform))
            {
                animator.enabled = false;

                targets.Add(other.gameObject.transform);

                shooter.SetTarget(targets[0]);
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.gameObject.tag == "Enemy" && targets.Contains(other.gameObject.transform))
            {
                targets.Remove(other.transform);

                if (targets.Count != 0)
                {
                    shooter.SetTarget(targets[0]);
                }
                else
                {
                    shooter.SetTarget(null);
                }
            }
        }

        public void RemoveFromTargetList(Transform target)
        {
            targets.Remove(target);
        }
    }
}
