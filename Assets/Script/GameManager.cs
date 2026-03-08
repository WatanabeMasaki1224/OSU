using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public Spawner spawner;
    int score = 0;
    public TMPro.TMP_Text scoreText;

    private void Awake()
    {
        instance = this;
    }

    public void AddScore()
    {
        score++;
        scoreText.text = score.ToString();
        Debug.Log(score);
    }

    public void GameOver()
    {
        Debug.Log("GameOver");
        spawner.CancelInvoke();
    }
}
