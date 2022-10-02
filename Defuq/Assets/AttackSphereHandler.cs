using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Animations.Enemies;
using System.Events;
using Controllers.Creatures;

public class AttackSphereHandler : MonoBehaviour
{
    [SerializeField] AnimationSwitch creatureAnimation;
    [SerializeField] CreatureController creatureController;
    [SerializeField] CreatureEvents _enemyEvent;
    [SerializeField] CombatSystem _combSystem;
    private string PLAYERTAG = "Player";

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag(PLAYERTAG) && creatureAnimation.GetAttackState())
        {
            _combSystem.TakeDamage(creatureController.GetCurrentDamage(), PLAYERTAG);
        }
    }
   
}
