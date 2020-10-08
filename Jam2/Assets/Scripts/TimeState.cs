using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimeState : MonoBehaviour
{
    public static TimeState instance;
    public Text timeCounter;
    private DateTime loopTime;
    private bool running;
    public float elapsedTime;
    public float minutesPerSecond;

    private void Awake()    //setting up singleton
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Debug.Log("Instance already exists, destroying object!");
            Destroy(this);
        }
    }

    void Start()    //initialize
    {
        timeCounter.text = "Time 7:00 am";
        running = false;
        elapsedTime = 60 * 7f;  //7 am
        StartTime();
        InvokeRepeating("updateSec", 1f, 1f);
    }
    public void StartTime() //begin time
    {
        running = true;
        StartCoroutine(UpdateTime());
    }
    public void StopTime() //stop time
    {
        running = false;
    }
    public IEnumerator UpdateTime()
    {
        while(running)
        {
            elapsedTime += Time.deltaTime*minutesPerSecond;
            loopTime = DateTime.Today.AddMinutes(elapsedTime);
            string loopTimeStr = "Time: " + loopTime.ToString("h':'mm tt");
            timeCounter.text = loopTimeStr;

            yield return null;
        }
    }
    public int getHour()
    {
        return loopTime.Hour;
    }
    public int getMinute()
    {
        return loopTime.Minute;
    }
    private void updateSec()
    {
        if (getHour() >= 22 )
        {
            SceneManager.LoadScene("testing");
        }
    }
}
