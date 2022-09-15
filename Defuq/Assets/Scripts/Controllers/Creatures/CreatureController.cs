using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Data.Creatures;
using System.Events;
using Systems.Creatures;


namespace Controllers.Creatures
{
    public class CreatureController : MonoBehaviour
    {

        [SerializeField] EnemyStatsSO data;
        [SerializeField] CreatureEvents enemyEvent;
        [SerializeField] LineOfSight LineOfSight;
        [SerializeField] NavMeshAgent agent;

        private int currentHealth;
        private int currentDamage;


        private void Awake()
        {
            currentHealth = data.maxHealth;
            currentDamage = data.attackDamage;

            if (LineOfSight == null) return;
            LineOfSight.Init(data.visionRange, data.visionAngle, data.attackRange);

        }

        private void Update()
        {
            if (LineOfSight.targetsAquired.Count > 0)
            {
                agent.SetDestination(LineOfSight.targetsAquired[0].transform.position);
                agent.isStopped = false;
                while (LineOfSight.targetInAttRange.Count > 0 && agent.isStopped == false)
                {
                    agent.isStopped = true;
                }
            }
        }


        // Can be change if we decide the player manage all combat logic
        private void TakeDamage(int damageTaken)
        {
            if (currentHealth > 0)
            {
                currentHealth -= damageTaken;
                // Debug
                Debug.Log("Damage Taken");
            }
            else if (currentHealth <= 0)
            {
                currentHealth = 0;
                enemyEvent.enemyKilled.Invoke();
                Debug.Log("Enemy Killed");
            }
        }
    }

}

// Code By Amit
