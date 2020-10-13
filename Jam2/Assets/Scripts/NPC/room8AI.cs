using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class room8AI : MonoBehaviour
{
    public MoveAI moveAi;
    public UnityEngine.AI.NavMeshAgent agent;
    public GameObject coffee;
    public GameObject br8Key;
    public GameObject talk1;
    public GameObject talk2;

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
            Destroy(talk1);
            coffee.SetActive(true);
            current = 1;
        }

        if (TimeState.instance.getHour() >= 14 && TimeState.instance.getHour() < 15)
        {
                moveAi.SetDestination(1);
        }

        if (TimeState.instance.getHour() >= 15 && current == 1)
        {
            talk2.SetActive(true);
            moveAi.SetDestination(2);
            br8Key.SetActive(true);
            current = 2;
        }

        if (TimeState.instance.getHour() >= 20 && current == 2)
        {
            Destroy(talk2);
            moveAi.SetDestination(3);
            current = 3;
        }
    }
}
