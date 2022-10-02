using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Controllers.Creatures;
using Data.Save;
using Data.Creatures;

public class SaveHandler : MonoBehaviour
{
    public SaveFields saveFile = new SaveFields();

    [SerializeField] Transform current_PlayerTransform;
    [SerializeField] PlayerData current_PlayerData;
    [SerializeField] List<GameObject> current_enemies;


    private string json;

    private void Awake()
    {
        SaveManager.Initialize();

        // Delete LoadGame in case you only want to load game when prompting with menu buttons!
        LoadGame();
    }


    public void SaveTrigger()
    {
        saveFile.savedPlayerVector3 = current_PlayerTransform.position;
        saveFile.savedPlayerHealth = current_PlayerData.GetCurrentHealth();

        #region# Enemy V3 and Health Save Attempt

        saveFile.savedEnemiesHealth.Clear();
        saveFile.savedEnemiesV3.Clear();

        for (int i = 0; i < current_enemies.Count; i++)
        {
            CreatureController controller = current_enemies[i].GetComponent<CreatureController>();
            saveFile.savedEnemiesV3.Add(current_enemies[i].transform.position);
            saveFile.savedEnemiesHealth.Add(controller.GetCurrentHealth());
        }

        #endregion#

        json = JsonUtility.ToJson(saveFile);
        SaveManager.Save(json);

        Debug.Log(SaveManager.Load());
    }

    public void LoadGame()
    {
        if (SaveManager.Load() != null) // Maybe add in a condtion in which we dont load if there arent any enemies?
        {
            string saveString = SaveManager.Load();
            SaveFields savedObject = JsonUtility.FromJson<SaveFields>(saveString);

            current_PlayerTransform.position = savedObject.savedPlayerVector3;
            current_PlayerData.SetCurrentHealth(savedObject.savedPlayerHealth);

            #region# Enemy V3 and Health Load Attempt
            for (int i = 0; i < savedObject.savedEnemiesV3.Count; i++)
            {
                CreatureController controller = current_enemies[i].GetComponent<CreatureController>();
                current_enemies[i].transform.position = savedObject.savedEnemiesV3[i];
                controller.SetCurrentHealth(MaxHpLimiter(controller));
            }
            #endregion#
        }
    }

    private int MaxHpLimiter(CreatureController controller)
    {
        if (controller.GetCurrentHealth() > controller.GetMaxHp())
        {
            return controller.GetMaxHp();
        }
        else { return controller.GetCurrentHealth(); }
    }
}
