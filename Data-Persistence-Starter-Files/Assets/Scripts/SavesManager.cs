using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class SavesManager : MonoBehaviour
{
    // Start is called before the first frame update
    static public SavesManager Instance;

    public string CurrPlayer;
    public class SaveData
    {
        public string HighScorePlayer = "Player1";
        public int HighScore = 0;
    }

    public Text BestScoreText;
    public SaveData BestPlayer;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        LoadHighScore();
    }

    public void SaveHighScore()
    { 
        SaveData data = new SaveData();
        data.HighScore = BestPlayer.HighScore;
        data.HighScorePlayer = BestPlayer.HighScorePlayer;

        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
        Debug.Log("File " + Application.persistentDataPath + "/savefile.json succesfully saved");
    }

    public void LoadHighScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            BestPlayer = JsonUtility.FromJson<SaveData>(json);
            Debug.Log("HighScore succesfully Loaded: PlayerName: " + BestPlayer.HighScorePlayer + "; Score: " + BestPlayer.HighScore);
        }
        else
        {
            Debug.Log("File " + path + " does not exist");
        }
    }

    //public void SaveColor()
    //{
    //    SaveData data = new SaveData();
    //    data.TeamColor = teamColor;

    //    string json = JsonUtility.ToJson(data);

    //    File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);

    //    Debug.Log("File " + Application.persistentDataPath + "/savefile.json succesfully saved");
    //}

    //public void LoadColor()
    //{
    //    string path = Application.persistentDataPath + "/savefile.json";
    //    if (File.Exists(path))
    //    {
    //        string json = File.ReadAllText(path);
    //        SaveData data = JsonUtility.FromJson<SaveData>(json);

    //        teamColor = data.TeamColor;

    //        Debug.Log("Color succesfully Loaded");
    //    }
    //    else
    //    {
    //        Debug.Log("File " + path + " does not exist");
    //    }
    //}
}
