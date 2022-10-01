using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Animations.Enemies;
using System.Events;
using Controllers.Creatures;

public class AttackSphereHandler : MonoBehaviour
{
    [SerializeField] AnimationSwitch cretureAnimation;
    [SerializeField] CreatureController creatureController;
    [SerializeField] CreatureEvents _enemyEvent;
    [SerializeField] CombatSystem _combSystem;
    private string PLAYERTAG = "Player";
    private string ENEMYTAG = "Enemy";

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(PLAYERTAG) && cretureAnimation.GetAttackState())
        {
            _enemyEvent.enemyGotHit.Invoke();
            _combSystem.TakeDamage(creatureController.GetCurrentDamage(), ENEMYTAG);
        }
    }
    
    //private void OnCollisionEnter(Collision collision)
    //{
    //    if (collision.gameObject.tag == PLAYERTAG && cretureAnimation.GetAttackState() == true)
    //    {
    //        Debug.Log("Attack Hit!");
    //    }
    //}
}
