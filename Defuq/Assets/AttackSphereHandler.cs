using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Animations.Enemies;

public class AttackSphereHandler : MonoBehaviour
{
    [SerializeField] AnimationSwitch cretureAnimation;

    private string PLAYERTAG = "Player";


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == PLAYERTAG && cretureAnimation.GetAttackState() == true)
        {
            Debug.Log("Attack Hit!");
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
