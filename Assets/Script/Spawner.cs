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

    private void Start()
    {
        InvokeRepeating("Spawn", 1f, 0.5f);
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
    }


}
