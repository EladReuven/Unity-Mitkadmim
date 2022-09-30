using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public void NewGameBtn()
    {
        SceneManager.LoadScene(1);
    }

    public void LoadGameBtn()
    {
        //TODO
    }

    public void OptionBtn()
    {
        //TODO
    }

    public void ExitBtn()
    {
        Application.Quit();
    }
}
