using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{

    public GameObject buttons;
    public void NewGameBtn()
    {
        SceneManager.LoadScene("Level");
        SceneManager.LoadScene("options", LoadSceneMode.Additive);
        SceneManager.LoadScene("HUD", LoadSceneMode.Additive);
    }

    public void LoadGameBtn()
    {
        //TODO load game
    }

    public void OptionBtn()
    {
        buttons.SetActive(!buttons.activeInHierarchy);
        OptionsMenuController.instance.ToggleMenu();

    }

    public void ExitBtn()
    {
        Application.Quit();
    }
}
