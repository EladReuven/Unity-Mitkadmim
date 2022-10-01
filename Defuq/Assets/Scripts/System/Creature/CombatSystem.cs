using Controllers.Creatures;
using Data.Creatures;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatSystem : MonoBehaviour
{
    [SerializeField] private PlayerData _playerData;
    [SerializeField] private CreatureController _enemyData;


    public void TakeDamage(int takenDamage,string creatureType)
    {
        if (creatureType.Equals("Player"))
        {
            if (takenDamage < 0)
                takenDamage = 0;
            int playerHealth = _playerData.GetCurrentHealth();
            playerHealth -= takenDamage;
            if (playerHealth < 0)
            { 
                playerHealth = 0;
            }
            _playerData.SetCurrentHealth(playerHealth);
            Debug.Log("Player's health: "+ _playerData.GetCurrentHealth());
        }
        else if (creatureType.Equals("Enemy"))
        {
            int enemyCurrentHealth=_enemyData.GetCurrentHealth();
            enemyCurrentHealth -= takenDamage;
            if (enemyCurrentHealth < 0)
            {
                enemyCurrentHealth = 0;
                _enemyData.GetEnemyEvent().enemyKilled.Invoke();
                if(gameObject.layer == 7)
                {
                    GameManager.instance.WinGame();
                }
                GameManager.instance.enemiesAlive--;
                Debug.Log("Enemy Killed");
            }
            _enemyData.SetCurrentHealth(enemyCurrentHealth);
            Debug.Log("Enemy's health: " + _enemyData.GetCurrentHealth());
        }
    }
    

}
