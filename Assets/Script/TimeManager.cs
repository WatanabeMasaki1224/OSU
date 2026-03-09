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
    bool ended = false; 

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
        if (!ended && currentTime <= 0)
        {
            ended = true;
            currentTime = 0;
            OntimeEnd?.Invoke();
        }
    }

    public float GetTime()
    {
        return currentTime;
    }

    public void ResetTimer()
    {
        currentTime = gameTime;
        ended = false;
        if(timeText != null) 
            timeText.text = Mathf.Ceil(currentTime).ToString();
    }
}
