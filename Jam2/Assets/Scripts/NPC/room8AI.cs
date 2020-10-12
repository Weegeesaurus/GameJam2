using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class room8AI : MonoBehaviour
{
    public MoveAI moveAi;
    public UnityEngine.AI.NavMeshAgent agent;
    public GameObject coffee;
    public GameObject br8Key;

    private int current=0;
    // Update is called once per frame
    void Start()
    {
        InvokeRepeating("updateSec", 1f, 1f);
    }
    private void updateSec()
    {
        if (TimeState.instance.getHour() >= 7 && TimeState.instance.getHour() < 8)
        {
            moveAi.SetDestination(0);
        }

        if (TimeState.instance.getHour() >= 10 && current==0)
        {
            coffee.SetActive(true);
            current = 1;
        }

        if (TimeState.instance.getHour() >= 14 && TimeState.instance.getHour() < 15)
        {
                moveAi.SetDestination(1);
        }

        if (TimeState.instance.getHour() >= 15 && current == 1)
        {
            moveAi.SetDestination(2);
            br8Key.SetActive(true);
            current = 2;
        }

        if (TimeState.instance.getHour() >= 20)
        {
            moveAi.SetDestination(3);
        }
    }
}
