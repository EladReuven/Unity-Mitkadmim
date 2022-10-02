using Data.Creatures;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public Animator doorAnimator;
    public PlayerData playerData;
    // Added By Amit For Save ? ? ?
    public SaveHandler saveHandler;
    // Check Me ?  ?  ?
    public UnityEvent OnGameWon, OnGameOver;
    public OptionsMenuController optionsMenuController;

    public int enemiesAlive = 8;
    bool _bossPhase = false;
    bool isGameRunnnig = true;

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
    private void Update()
    {
        if(enemiesAlive <= 0 && !_bossPhase)
        {
            doorAnimator.SetBool("openDoor", true);
            _bossPhase = true;
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePuase();
        }
    }

    private void TogglePuase()
    {
        //toggle time scale
        Time.timeScale = isGameRunnnig ? 0 : 1;
        isGameRunnnig = !isGameRunnnig;

        //toggle the option menu
        optionsMenuController.ToggleMenu();
    }

    [ContextMenu("Win")]
    public void WinGame()
    {
       StartCoroutine(GameEndSequence(OnGameWon));
    }

    [ContextMenu("Game Over")]
    public void GameOver()
    {
        StartCoroutine (GameEndSequence(OnGameOver));
    }

    IEnumerator GameEndSequence(UnityEvent unityEvent)
    {
        unityEvent?.Invoke();
        yield return new WaitForSeconds(4f);
        SceneManager.LoadScene(0);

    }

    [ContextMenu("kill Enemy")]
    public void killEnemy()
    {
        enemiesAlive--;
    }
}
