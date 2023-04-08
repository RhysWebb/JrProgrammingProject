using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class MainManager : MonoBehaviour
{
    public static MainManager Instance
    {
        get;
        private set;
    } 


    // Variables
    public Color teamColour;

    private void Awake()
    {
        // start of new code
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        // end of new code

        Instance = this;
        DontDestroyOnLoad(gameObject);
        LoadColor();
    }
    [System.Serializable]
    class SaveData
    {
        public Color teamColour;
    } // Class

    public void SaveColor()
    {
        SaveData data = new SaveData();
        data.teamColour = teamColour;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "saveFile.json", json);
    }

    public void LoadColor()
    {
        string path = Application.persistentDataPath + "saveFile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            teamColour = data.teamColour;
        }
    }
} // Class
