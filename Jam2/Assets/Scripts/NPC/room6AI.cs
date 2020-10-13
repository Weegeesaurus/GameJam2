using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class room6AI : MonoBehaviour
{
    public MoveAI moveAi;
    public UnityEngine.AI.NavMeshAgent agent;
    public GameObject powerKey;
    public GameObject tp;
    public GameObject talk;

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
            if (current == 0)
            {
                Destroy(talk);
                moveAi.SetDestination(0);
                current = 1;
            }
            if (!agent.pathPending)
            {
                if (agent.remainingDistance <= agent.stoppingDistance)
                {
                    if (!agent.hasPath || agent.velocity.sqrMagnitude == 0f)
                    {
                        Destroy(powerKey);
                    }
                }
            }
        }

        if (TimeState.instance.getHour() >= 12 && TimeState.instance.getMinute() >= 10 && TimeState.instance.getHour() < 13)
        {
            moveAi.SetDestination(1);
        }

        if (TimeState.instance.getHour() >= 14 && TimeState.instance.getHour() < 16)
        {
            if (current == 1)
            {
                moveAi.SetDestination(2);
                current = 2;
            }
            if (!agent.pathPending)
            {
                if (agent.remainingDistance <= agent.stoppingDistance)
                {
                    if (!agent.hasPath || agent.velocity.sqrMagnitude == 0f)
                    {
                        Destroy(tp);
                    }
                }
            }
        }

        if (TimeState.instance.getHour() >= 16 && TimeState.instance.getMinute() >= 30)
        {
            moveAi.SetDestination(3);
        }

        if (TimeState.instance.getHour() >= 18)
        {
            moveAi.SetDestination(0);
        }

    }
}
