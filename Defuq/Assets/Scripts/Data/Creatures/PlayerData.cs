using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Data.Creatures
{ 
    public class PlayerData : MonoBehaviour
    {
        [SerializeField] private int _maxHealth;
        [SerializeField] private int _currentHealth;
        [SerializeField] private int _attackDamage;
        [SerializeField] private int _armor;       

        public int GetCurrentHealth() 
        {
            return _currentHealth;
        }
        public int GetAttackDamage()
        {
            return _attackDamage;
        }
        public int GetArmor() 
        {
            return _armor;
        }
        public void SetAttackDamage(int attackDamage)
        {
            _attackDamage = attackDamage;
        }
        public void SetCurrentHealth(int health)
        {
            _currentHealth = health;
        }
        public void SetArmor(int armor) 
        {
            _armor = armor;
        }
    }
}
