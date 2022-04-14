using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public static Timer instance;

    public Text _timeCounter;

    private TimeSpan _timePlaying;
    private bool _timerGoing;

    private float _elapsedTime;

    public void Awake()
    {
        instance = this;
    }

    
    void Start()
    {
        _timeCounter.text = "00:00:00";
        _timerGoing = false;

        BeginTimer();
    }

    
    

    public void BeginTimer()
    {
        _timerGoing = true;
        _elapsedTime = 0f;

        StartCoroutine(UpdateTimer());
    }
    
    public void EndTimer()
    {
        
        _timerGoing = false;
    }

    IEnumerator UpdateTimer()
    {
        while (_timerGoing)
        {
            _elapsedTime += Time.deltaTime;
            _timePlaying = TimeSpan.FromSeconds(_elapsedTime);
            string timePlayingStr = _timePlaying.ToString("mm' : 'ss' . 'ff");
            _timeCounter.text = timePlayingStr;

            yield return null;
        }


    }

}
