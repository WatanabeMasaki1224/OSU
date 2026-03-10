using Unity.VectorGraphics;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class Title : MonoBehaviour
{
    public Image fadeImage;
    public float fadeDuration = 1.0f;
    public void OnStartButton()
    {
        StartCoroutine(Fade());
    }

    IEnumerator Fade()
    {
        float t = 0f;
        Color c =fadeImage.color;
        while (t < fadeDuration)
        {
            t += Time.deltaTime;
            c.a = Mathf.Lerp(0f, 1f, t / fadeDuration);
            fadeImage.color = c;
            yield return null;
        }
        SceneManager.LoadScene("MainGame");
    }
}
