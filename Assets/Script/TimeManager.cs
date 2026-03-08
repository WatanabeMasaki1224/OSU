using System;
using TMPro;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    public static TimeManager instance;
    public float gameTime = 60f;
    float currentTime;
    public event Action OntimeEnd;
    public TMP_Text timeText;

    void Awake()
    {
        instance = this;
        currentTime = gameTime;
    }

    // Update is called once per frame
    void Update()
    {
        currentTime -= Time.deltaTime;
        timeText.text = Mathf.Ceil(currentTime).ToString();
        if (currentTime <= 0)
        {
            currentTime = 0;
            OntimeEnd?.Invoke();
        }
    }

    public float GetTime()
    {
        return currentTime;
    }
}
