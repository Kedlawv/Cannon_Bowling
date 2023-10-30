using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Linq;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;
    public LoadSceneManager loadSceneManager;
    
    public Score CurrentScore { get; set; }
    public ScoresContainer scoresContainer = new ScoresContainer();


    private void Awake()
    {
        if(Instance != null)
        {
            Destroy(this.gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(this.gameObject);
        LoadAllScores();
    }

    private void Start()
    {
        CurrentScore = new Score();
        LogAllScores();
    }

    public void SaveAllScoresToDisk()
    {
        string filePath = Path.Combine(Application.persistentDataPath, "savefile.json");
        string jsonScores = JsonUtility.ToJson(scoresContainer);

        try
        {
            File.WriteAllText(filePath, jsonScores);
        }
        catch (System.Exception e)
        {
            Debug.LogError("Error while saving file: " + e.Message);
        }
        
    }

    public void LoadAllScores()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string jsonScores = File.ReadAllText(path);
            ScoresContainer scoresContainer = JsonUtility.FromJson<ScoresContainer>(jsonScores);
            this.scoresContainer = scoresContainer;
        }
    }

    public void roundOver(int count)
    {
        CurrentScore.Count = count;
        scoresContainer.AddScore(CurrentScore);
        SaveAllScoresToDisk();
        LogAllScores();
        loadSceneManager.LoadScoreBoard();
        LogAllScores();
    }

    public void LogAllScores()
    {
        Debug.Log("All Scores:");
        foreach (Score score in scoresContainer.GetAllScores()) 
        {
            Debug.Log(score.PlayerName + ":" + score.Count);
        }
    }

    // todo create a scene manager and load the game on Play button click 
}
