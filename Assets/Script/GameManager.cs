using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    int score = 0;

    private void Awake()
    {
        instance = this;
    }

    public void AddScore()
    {
        score++;
        Debug.Log(score);
    }

    public void GameOver()
    {
        Debug.Log("GameOver");
    }
}
