﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Rendering.Universal;
using UnityEngine.Rendering;

public class TimeState : MonoBehaviour
{
    public static TimeState instance;
    public Text timeCounter;
    private DateTime loopTime;
    private bool running;
    private float elapsedTime;
    public float minutesPerSecond;
    public float BaseMPS;
    public float FastMPS;
    public GameObject volume;
    private Vignette vig;

    private bool OutageTrigger=false;
    private bool CrashTrigger=false;
    private bool GunTrigger=false;

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
        Volume vol = volume.GetComponent<Volume>();
        vol.sharedProfile.TryGet<Vignette>(out vig);

        timeCounter.text = "Time 7:00 am";
        running = false;
        elapsedTime = 60 * 7f;  //7 am
        StartTime();
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
    private void Update()
    {
        if (getHour() < 8)      //fix vignette
        {
            vig.intensity.value = .1f;
        }
        if (getHour() == 11 && !OutageTrigger)//power off house
        {
            PlayerState.instance.PowerOff();
            OutageTrigger = true;
        }

        if (getHour() == 13 && !PlayerState.instance.HousePower)    //turn on house
        {
            PlayerState.instance.PowerOn();
        }

        if (getHour() == 15 && !CrashTrigger)   //cause a car crash
        {
            PlayerState.instance.Crash();
            CrashTrigger = true;
        }

        if (getHour() == 21 && !GunTrigger)     //murder happens
        {
            PlayerState.instance.Gunshot();
            GunTrigger = true;
            vig.intensity.value = .6f;
        }

        if (getHour() >= 22 )       //sleep
        {
            BlackoutManager.instance.FadeOut();
            if (getMinute() >= 2)
            {
                SceneManager.LoadScene("MainLevel");
            }
        }

        if (getHour() >= 21 && getMinute() >= 30)   //increase vignette
        {
            vig.intensity.value = ((getMinute()-30)/ 30f)*.4f+.6f;
        }
    }
}
