using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    [Header("AmbientSFX")]
    public AudioClip ambientForest;

    [Header("PlayerSFX")]
    public AudioSource playerAudioSource;
    public AudioSource swordAudioSource;
    public AudioClip[] swordSwings; //done
    public AudioClip[] swordHit; //done
    public AudioClip[] playerWalkSounds; //done
    public AudioClip playerHit; //done

    [Header("PlayerSFX")]
    public AudioSource zombieAudioSource;
    public AudioClip[] zombieTargetAquired; //done
    public AudioClip zombieDeath; 
    public AudioClip[] zombieAttack;
    public AudioClip[] zombieChase;


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    public void PlayerSwingSFX()
    {
        Debug.Log("Sword Swing Sound");
        swordAudioSource.clip = swordSwings[Random.Range(0, swordSwings.Length)];
        swordAudioSource.Play();
    }

    public void PlayerWalkSFX()
    {
        if(playerAudioSource.isPlaying)
            return;
        playerAudioSource.clip = playerWalkSounds[Random.Range(0, playerWalkSounds.Length)];
        playerAudioSource.Play();
    }

    public void PlayerHit()
    {
        playerAudioSource.clip = playerHit;
        playerAudioSource.Play();
    }

    public void SwordHit()
    {
        swordAudioSource.clip = swordHit[Random.Range(0, swordHit.Length)];
        swordAudioSource.Play();
    }

    public void ZombieTargetAquired()
    {
        if (zombieAudioSource.isPlaying)
            return;
        zombieAudioSource.clip = zombieTargetAquired[Random.Range(0, zombieTargetAquired.Length)];
        zombieAudioSource.Play();
    }

    public void ZombieAttack()
    {
        zombieAudioSource.clip = zombieAttack[Random.Range(0, zombieAttack.Length)];
        zombieAudioSource.Play();
    }

    public void ZombieDeath()
    {
        zombieAudioSource.clip = zombieDeath;
        zombieAudioSource.Play();
    }
}
