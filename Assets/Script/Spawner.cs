using UnityEngine;
using TMPro;

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

    public WordData[] words;

    private void Start()
    {
        InvokeRepeating("Spawn", 1f, 1f);
    }

    public void Spawn()
    {
        WordData data = words[Random.Range(0, words.Length)];
        GameObject obj = Instantiate(buttonPrefab,parent);
        obj.GetComponentInChildren<TMP_Text>().text = data.word;
        WordButton wb = obj.GetComponent<WordButton>();
        wb.isCorrect = data.isCorrect;
    }


}
