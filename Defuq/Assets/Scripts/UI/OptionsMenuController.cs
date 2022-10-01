using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OptionsMenuController : MonoBehaviour
{
    public static OptionsMenuController instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            ToggleMenu();
        }
        else
        {
            Destroy(gameObject);
        }

    }

    public void VoluemSlider(float value)
    {
        //TODO
    }

    public void LoadBtn()
    {
        //TODO
    }

    public void SaveBtn()
    {
        //TODO
    }

    public void ExitBtn()
    {
        SceneManager.LoadScene(0);
    }

    public void ToggleMenu()
    {
        gameObject.SetActive(!gameObject.activeInHierarchy);
    }
}
