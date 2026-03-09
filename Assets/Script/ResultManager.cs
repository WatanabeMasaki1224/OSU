using System.Collections.Generic;
using NUnit.Framework;
using NUnit.Framework.Constraints;
using TMPro;
using UnityEngine;

public class ResultManager : MonoBehaviour
{
    public TMP_Text scoreText;
    public TMP_Text rankingText;

    private void Start()
    {
        int score = GameManager.instance.score;
        scoreText.text = "ÉXÉRÉA:" + score;
        SaveScore(score);
        Ranking();
    }

    void SaveScore(int score)
    {
        List<int> scores = new List<int>();
        for (int i = 0; i < 5; i++)
        {
            scores.Add(PlayerPrefs.GetInt("Score" + i, 0));
        }

        scores.Add(score);
        scores.Sort((a, b) => b.CompareTo(a));
        scores = scores.GetRange(0, Mathf.Min(5, scores.Count));

        for (int i = 0; i < scores.Count; i++)
        {
            PlayerPrefs.SetInt("Score" + i, scores[i]);
        }
        PlayerPrefs.Save();
    }

    void Ranking()
    {
        rankingText.text = "";

        for (int i = 0; i < 5; i++)
        {
            int score = PlayerPrefs.GetInt("Score" + i, 0);
            rankingText.text += (i + 1) + " : " + score + "\n";
        }
    }
}
