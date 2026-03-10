using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public int score = 0;
    public TMPro.TMP_Text scoreText;
    public string lastWord;
    public GameObject gameOverUI;
    public GameObject gameClearUI;

    private void Start()
    {
        instance = this;

        if(TimeManager.instance != null)
        {
            TimeManager.instance.OntimeEnd += GameClear;
        }
    }


    public void AddScore()
    {
        score++;
        scoreText.text = score.ToString();
        Debug.Log(score);
    }

    public void GameOver(string word)
    {
        Debug.Log("GameOver");
        lastWord = word;
        Spawner spawner = FindAnyObjectByType<Spawner>();
        if(spawner != null)
        {
            spawner.CancelInvoke();
            spawner.WordDerete();
        }
        if (gameOverUI != null)
            gameOverUI.SetActive(true);
        StartCoroutine(GoResult());
        Debug.Log("GameOver");
    }

    public void GameClear()
    {
        FindAnyObjectByType<Spawner>().CancelInvoke();
        FindAnyObjectByType<Spawner>().WordDerete() ;
        if(gameClearUI != null) 
            gameClearUI.SetActive(true);
        StartCoroutine (GoResult());
        Debug.Log("GameClear");
    }

    IEnumerator GoResult()
    {
        PlayerPrefs.SetInt("LastScore", score);
        PlayerPrefs.Save();
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("Result");
    }

    public void ResetGame()
    {
        score = 0;
        if (scoreText != null)
            scoreText.text = score.ToString();
        lastWord = "";
    }
}
