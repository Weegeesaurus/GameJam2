﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FastFoward : MonoBehaviour
{
    private Image img;
    // Update is called once per frame
    void Start()
    {
        img = gameObject.GetComponent<Image>();
        img.enabled = false;
    }
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            TimeState.instance.minutesPerSecond = TimeState.instance.FastMPS;
            img.enabled = true;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            TimeState.instance.minutesPerSecond = TimeState.instance.BaseMPS;
            img.enabled = false;
        }
    }
}
