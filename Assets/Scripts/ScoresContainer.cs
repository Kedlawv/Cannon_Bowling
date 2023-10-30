using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

[System.Serializable]
public class ScoresContainer
{
    [SerializeField]
    private List<Score> AllScores = new List<Score>();

    public void AddScore(Score score)
    {
        this.AllScores.Add(score);

        List<Score> top5Scores = this.AllScores
            .OrderByDescending(score => score.Count)
            .Take(5)
            .ToList();

        AllScores = top5Scores;
    }

    public List<Score> GetAllScores()
    {
        return this.AllScores;
    }

    public void SetAllScores(List<Score> allScores)
    {
        this.AllScores = allScores;
    }
}
