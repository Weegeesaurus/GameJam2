using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class room4AI : MonoBehaviour
{
    public MoveAI moveAi;

    private int current=0;
    // Update is called once per frame
    void Start()
    {
        InvokeRepeating("updateSec", 1f, 1f);
    }
    private void updateSec()
    {
        if (TimeState.instance.getHour() >= 11 && TimeState.instance.getHour() < 12)
        {
            moveAi.SetDestination(1);
        }


        if (TimeState.instance.getHour() >= 12 && TimeState.instance.getMinute() >= 30)
        {
            moveAi.SetDestination(0);
        }
    }
}
