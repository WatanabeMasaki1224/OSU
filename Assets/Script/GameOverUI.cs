using UnityEngine;
using TMPro;

public class GameOverUI : MonoBehaviour
{
    public TMP_Text lastWordText;
    public TMP_Text scoreText;

    private void OnEnable()
    {
        lastWordText.text = "間違えた単語:" + GameManager.instance.lastWord;
        scoreText.text = "スコア:" + GameManager.instance.score;
    }
}
