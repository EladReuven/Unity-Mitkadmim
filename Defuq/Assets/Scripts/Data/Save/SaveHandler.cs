using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Data.Save;

public class SaveHandler : MonoBehaviour
{
    public SaveFields saveFile = new SaveFields();

    [SerializeField] Transform current_PlayerTransform;
    
    private string json;

    private void Awake()
    {
        SaveManager.Initialize();

        LoadGame();
    }

    private void Start()
    {
        InvokeRepeating("SaveTrigger", 5, 20);
    }

    public void SaveTrigger()
    {
        saveFile.playerTransform = current_PlayerTransform;

        json = JsonUtility.ToJson(saveFile);
        SaveManager.Save(json);

        Debug.Log(SaveManager.Load());
    }

    public void LoadGame()
    {
        if (SaveManager.Load() != null)
        {
            string saveString = SaveManager.Load();
            SaveFields savedObject = JsonUtility.FromJson<SaveFields>(saveString);

            current_PlayerTransform = savedObject.playerTransform;
        }
    }
}
