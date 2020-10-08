using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestAI : MonoBehaviour
{
    public MoveAI moveAi;
    // Update is called once per frame
    void Start()
    {
        InvokeRepeating("updateSec", 1f, 1f);
    }
    private void updateSec()
    {
        if (TimeState.instance.getHour() >= 11)
        {
            moveAi.SetDestination(0);
        }

        if (TimeState.instance.getHour() >= 14)
        {
            moveAi.SetDestination(1);
        }

        if (TimeState.instance.getHour() >= 20)
        {
            moveAi.SetDestination(2);
        }
    }
}
