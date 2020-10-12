using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OfficePAths : MonoBehaviour
{
    public float[] hour;
    public MoveAI moveAi;
    private int count = 0;
    void Start()
    {
        InvokeRepeating("updateSec", 1f, 1f);
    }
    private void updateSec()
    {
        if (TimeState.instance.getHour() >= hour[count]&&TimeState.instance.getHour() <= hour[count+1])
        {
            moveAi.SetDestination(count);
            count++;
        }
    }
    public void Skip()
    {
        if(count < hour.Length-1)
        {
            moveAi.SetDestination(count);
            count++;
        }
    }
}
