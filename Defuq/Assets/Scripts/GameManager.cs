using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    bool isGameRunnnig = true;
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
}
