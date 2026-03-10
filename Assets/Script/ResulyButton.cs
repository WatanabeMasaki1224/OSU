using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ResulyButton : MonoBehaviour
{
    public Image fadeImage;
    public float fadeDuration = 0.5f;

    public void RetryButton()
    {
        StartCoroutine(FadeAndLoad("MainGame"));
    }

    public void TitleButton()
    {
        StartCoroutine(FadeAndLoad("Start"));
    }

    private IEnumerator FadeAndLoad(string sceneName)
    {
        // フェードイン（黒くなる）
        float t = 0f;
        Color c = fadeImage.color;
        while (t < fadeDuration)
        {
            t += Time.deltaTime;
            c.a = Mathf.Lerp(0f, 1f, t / fadeDuration);
            fadeImage.color = c;
            yield return null;
        }

        // シーン切替
        if (GameManager.instance != null) GameManager.instance.ResetGame();
        if (TimeManager.instance != null) TimeManager.instance.ResetTimer();

        SceneManager.LoadScene(sceneName);
    }
}
