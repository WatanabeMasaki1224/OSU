using UnityEngine;
using TMPro;
using JetBrains.Annotations;
using System.Collections.Generic;

public class Spawner : MonoBehaviour
{
    public GameObject buttonPrefab;
    public Transform parent;

    [System.Serializable]
    public class WordData
    {
        public string word;
        public bool isCorrect;
    }

    [System.Serializable]
    public class spawnPointData
    {
        public Transform point;
        public bool used;
    }

    public WordData[] words;
    public spawnPointData[] spawnPoints;
    private float spawnInterval = 0.8f; // 初期スポーン間隔
    private float lifetime = 2f;      // ボタンの消える時間
    private bool speedUp40 = false;
    private bool speedUp20 = false;

    private void Start()
    {
        InvokeRepeating("Spawn",spawnInterval, spawnInterval);
    }

    private void Update()
    {
        if (TimeManager.instance == null) return;
        float t = TimeManager.instance.GetTime();
        if(!speedUp40 && t <=40f)
        {
            spawnInterval = 0.5f;
            lifetime = 1.5f;
            ResetInvoke();
            speedUp40 = true;
            Debug.Log("40秒経過");
        }

        if (!speedUp20 && t <=20f)
        {
            spawnInterval = 0.3f;
            lifetime = 1f;
            ResetInvoke();
            speedUp20 = true;
            Debug.Log("20秒経過");
        }
    }

    void ResetInvoke()
    {
        CancelInvoke("Spawn");
        InvokeRepeating("Spawn",spawnInterval,spawnInterval);
    }



    public void Spawn()
    {
        WordData data = words[Random.Range(0, words.Length)];

        var availablePoints = new List<spawnPointData>();
        foreach (var p in spawnPoints)
        {
            if (!p.used) availablePoints.Add(p);
        }

        if (availablePoints.Count == 0) return; 

        spawnPointData point = availablePoints[Random.Range(0, availablePoints.Count)];
        GameObject obj = Instantiate(buttonPrefab, point.point.position, Quaternion.identity, parent);
        obj.GetComponentInChildren<TMP_Text>().text = data.word;
        WordButton wb = obj.GetComponent<WordButton>();
        wb.isCorrect = data.isCorrect;
        wb.spawnPoint = point;
        point.used = true;
        wb.StartAutoDestroy(lifetime);
    }

    public void WordDerete()
    {
        foreach (Transform child in parent)
        {
            Destroy(child.gameObject);
        }
    }
}
