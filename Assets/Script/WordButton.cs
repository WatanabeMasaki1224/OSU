using UnityEngine;

public class WordButton : MonoBehaviour
{
    public bool isCorrect;

    public void OnClick()
    {
        if(isCorrect)
        {
            GameManager.instance.AddScore();
        }
        else
        {
            GameManager.instance.GameOver();
        }
        Destroy(gameObject);    
    }
}
