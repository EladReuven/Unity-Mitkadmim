using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Data.Creatures
{
    public class PlayerData : MonoBehaviour
    {
        public int maxHealth;

        [SerializeField] private int _currentHealth;
        [SerializeField] private int _attackDamage;

        public UnityEvent<float> OnHealthValueChanged;
        public UnityEvent<float> OnArmorValueChanged;

        [ContextMenu ("isnull health")]
        public void IsValid() 
        {

            Debug.Log(_currentHealth);

        }


        public int GetCurrentHealth()
        {
            return _currentHealth;
        }
        public int GetAttackDamage()
        {
            return _attackDamage;
        }
        public void SetAttackDamage(int attackDamage)
        {
            _attackDamage = attackDamage;
        }
        public void SetCurrentHealth(int health)
        {
            _currentHealth = health;
            OnHealthValueChanged.Invoke(health);
        }

        [ContextMenu("Test Damage")]
        public void _testDamage()
        {
            SetCurrentHealth(GetCurrentHealth() - 5);
        }





    }
}
