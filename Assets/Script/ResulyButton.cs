using UnityEngine;
using UnityEngine.SceneManagement;

public class ResulyButton : MonoBehaviour
{
   public void RetryButton()
    {
        if (GameManager.instance != null)
            GameManager.instance.ResetGame();

        if(TimeManager.instance != null )
            TimeManager.instance.ResetTimer();

        SceneManager.LoadScene("MainGame");
    }

    public void TitleButton()
    {
        if(GameManager.instance != null) 
            GameManager.instance.ResetGame();

        if(TimeManager.instance != null)
            TimeManager.instance.ResetTimer();

        SceneManager.LoadScene("Start");
    }
}
