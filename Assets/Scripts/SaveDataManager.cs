using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SaveDataManager : MonoBehaviour
{


    public static SaveDataManager Instance;

    public string playerName;

    public int highScore;
    public string savedScoreName;

    private void Awake()
    {
        
        
        
        
        
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
        LoadHiScore();
        


    }

     [System.Serializable]
    class SaveData
    {
        public int savedScore;
        public string savedName;
    }

    public void UpdateHighScore( int newHighScore)
    {
        

        SaveData data = new SaveData();
        data.savedName = playerName;
        data.savedScore = newHighScore;

        string json = JsonUtility.ToJson(data);
        //where does persistentDataPath point to https://docs.unity3d.com/ScriptReference/Application-persistentDataPath.html
        File.WriteAllText(Application.persistentDataPath + "/hisavefile.json", json);
    }

    public void LoadHiScore()
    {
        string path = Application.persistentDataPath + "/hisavefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            savedScoreName = data.savedName;
            highScore = data.savedScore;
            
        }
        else{
            savedScoreName = playerName;
            highScore = 0;


        }
    }

    

}
