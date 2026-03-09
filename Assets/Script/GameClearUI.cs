using UnityEngine;
using TMPro;

public class GameClearUI : MonoBehaviour
{
    public TMP_Text scoreText;

    private void OnEnable()
    {
        scoreText.text = "ÉXÉRÉA" + GameManager.instance.score;
    }
}
