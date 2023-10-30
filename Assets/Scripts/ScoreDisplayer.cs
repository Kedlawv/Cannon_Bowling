using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreDisplayer : MonoBehaviour
{

    public GameObject OneScoreContainerPrefab;

    public void Start()
    {
        DisplayScores();
    }

    public void DisplayScores()
    {
        List<Score> allScores = ScoreManager.Instance.scoresContainer.GetAllScores();
        float currentYpos = 500;

        foreach(Score score in allScores)
        {
            var newScore = Instantiate(OneScoreContainerPrefab, this.transform);
            newScore.transform.position = new Vector3(this.transform.position.x, currentYpos, this.transform.position.z);
            GameObject uiName = newScore.transform.Find("NameText").gameObject;
            GameObject uiScore = newScore.transform.Find("ScoreText").gameObject;

            uiName.GetComponent<TextMeshProUGUI>().text = score.PlayerName;
            uiScore.GetComponent<TextMeshProUGUI>().text = score.Count.ToString();

            currentYpos -= 64;
        }
    }
}
