using System.Collections;
using UnityEngine;
using TMPro;

public class WordButton : MonoBehaviour
{
    public bool isCorrect;
    public Spawner.spawnPointData spawnPoint;

    public void OnClick()
    {
        if(isCorrect)
        {
            Audio.instance.PlayTrue();
            GameManager.instance.AddScore();
        }
        else
        {
            Audio.instance.PlayFalse();
            string word = GetComponentInChildren<TMP_Text>().text;
            GameManager.instance.GameOver(word);
        }
        spawnPoint.used = false;
        Destroy(gameObject);    
    }

    public void StartAutoDestroy(float lifetime)
    {
        StartCoroutine(AutoDestroy(lifetime));
    }

    IEnumerator AutoDestroy(float lifeTime)
    {
        yield return new WaitForSeconds(lifeTime);
        spawnPoint.used = false;
        Destroy(gameObject);
    }
}
