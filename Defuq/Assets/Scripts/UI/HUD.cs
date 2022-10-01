using Data.Creatures;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    public Slider healthBar;
    public GameObject gameOverScreen;
    public GameObject gameWonScreen;

    PlayerData playerData;
    private void Start()
    {
        playerData = GameManager.instance.playerData;

        playerData.OnHealthValueChanged.AddListener(SetHealthBarValue);
        GameManager.instance.OnGameOver.AddListener(ShowGameOverScreen);
        GameManager.instance.OnGameWon.AddListener(ShowGameWonScreen);

        SetHealthBarValue(playerData.GetCurrentHealth());
    }

    public void SetHealthBarValue(float value)
    {
        float percentage = value / playerData.maxHealth;
        healthBar.value = percentage;
    }

    public void ShowGameOverScreen()
    {
        gameOverScreen.SetActive(true);
    }
    public void ShowGameWonScreen()
    {
        gameWonScreen.SetActive(true);
    }
}
