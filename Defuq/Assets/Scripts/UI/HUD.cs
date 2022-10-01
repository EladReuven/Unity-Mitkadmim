using Data.Creatures;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    public Slider HealthBar;

    PlayerData playerData;
    private void Start()
    {
        playerData = GameManager.instance.playerData;

        playerData.OnHealthValueChanged.AddListener(SetHealthBarValue);

        SetHealthBarValue(playerData.GetCurrentHealth());
    }

    public void SetHealthBarValue(float value)
    {
        float percentage = value / playerData.maxHealth;
        HealthBar.value = percentage;
    }


}
