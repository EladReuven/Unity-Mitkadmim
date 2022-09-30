using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Data.Creatures;
using System.Events;
using Systems.Creatures;

namespace Controllers.Creatures
{
    public class CreatureController : MonoBehaviour
    {

        [SerializeField] EnemyStatsSO _data;
        [SerializeField] LineOfSight _lineOfSight;
        [SerializeField] CreatureEvents _enemyEvent;

        private int _currentHealth;
        private int _currentDamage;


        private void Awake()
        {
            _currentHealth = _data.maxHealth;
            _currentDamage = _data.attackDamage;
            if (_lineOfSight == null) return;
            _lineOfSight.Init(_data.visionRange, _data.visionAngle, _data.attackRange);
        }

        public int GetCurrentHealth() 
        {
            return _currentHealth;
        }
        public int GetCurrentDamage() 
        {
            return _currentDamage;
        }

        public CreatureEvents GetEnemyEvent()
        {
            return _enemyEvent;
        }
        public void SetCurrentHealth(int newHealth)
        {
            _currentHealth=newHealth;
        }
        public void SetCurrentDamage(int newDamage)
        {
            _currentDamage=newDamage;
        }

    }

}

// Code By Amit
