using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class OptionsMenuController : MonoBehaviour
{
    public static OptionsMenuController instance;
    public AudioMixer mainAudioMixer;

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
        mainAudioMixer.SetFloat("MasterVolume", Mathf.Log10(value) * 20);
    }

    public void LoadBtn()
    {
        //TODO // Added The Save Handler Script into game manager and trying 
        GameManager.instance.saveHandler.LoadGame();
    }

    public void SaveBtn()
    {
        //TODO
        GameManager.instance.saveHandler.SaveTrigger();
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
