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
        if (TimeState.instance.getHour()>=19 && TimeState.instance.getHour()<20 && PlayerState.instance.raid)
        {
            moveAi.SetDestination(6);
        }
        if (TimeState.instance.getHour() >= 21 && TimeState.instance.getHour() < 22)
        {
            moveAi.SetDestination(6);
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
