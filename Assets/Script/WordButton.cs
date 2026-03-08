using System.Collections;
using UnityEngine;

public class WordButton : MonoBehaviour
{
    public bool isCorrect;
    public Spawner.spawnPointData spawnPoint;


    private void Start()
    {
        StartCoroutine(AutoDestroy());
    }

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

    IEnumerator AutoDestroy()
    {
        yield return new WaitForSeconds(2f);
        spawnPoint.used = false;
        Destroy(gameObject);
    }
}
