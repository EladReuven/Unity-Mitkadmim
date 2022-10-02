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
        SceneManager.LoadScene("HUD", LoadSceneMode.Additive);
    }

    public void LoadGameBtn()
    {
        NewGameBtn();
        GameManager.instance.saveHandler.LoadGame();

    }

    public void OptionBtn()
    {
        buttons.SetActive(!buttons.activeInHierarchy);
        GameManager.instance.optionsMenuController.ToggleMenu();

    }

    public void ExitBtn()
    {
        Application.Quit();
    }
}
