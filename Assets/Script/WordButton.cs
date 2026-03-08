using System.Collections;
using UnityEngine;

public class WordButton : MonoBehaviour
{
    public bool isCorrect;
    public Spawner.spawnPointData spawnPoint;

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
