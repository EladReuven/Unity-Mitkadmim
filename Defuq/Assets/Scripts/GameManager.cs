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

    public PlayerData playerData;
    public UnityEvent OnGameWon, OnGameOver;

    bool isGameRunnnig = true;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    private void Update()
    {
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
        OptionsMenuController.instance.ToggleMenu();
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
}
