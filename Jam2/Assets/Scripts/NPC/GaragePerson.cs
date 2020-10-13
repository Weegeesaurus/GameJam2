using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GaragePerson : MonoBehaviour
{
    public MoveAI moveAi;
    public GameObject gun;

    private int current = 0;
    // Update is called once per frame
    void Start()
    {
        InvokeRepeating("updateSec", 1f, 1f);
    }
    private void updateSec()
    {
        if (TimeState.instance.getHour() >= 17 && current == 0)
        {
            moveAi.SetDestination(0);   //light
            current = 1;
        }

        if (TimeState.instance.getHour() >= 18 && current == 1)
        {
            moveAi.SetDestination(1);   //door
            current = 2;
        }
        if (TimeState.instance.getHour() == 18 && TimeState.instance.getMinute() >= 30 && current == 2 && PlayerState.instance.GarageLock == true)
        {
            moveAi.SetDestination(2);   //back
            current = 3;
            GameObject obj = Instantiate(PlayerState.instance.KnockSound);
            Destroy(obj, 5f);
        }

        if (TimeState.instance.getHour() >= 19 && current == 3)
        {
            PlayerState.instance.canRecord = true;
            gun.SetActive(true);
            moveAi.SetDestination(0);
            current = 4;
        }

        if (TimeState.instance.getHour() >= 19 && TimeState.instance.getMinute() >= 40 && current == 4)
        {
            PlayerState.instance.canRecord = false;
            moveAi.SetDestination(1);
            current = 5;
        }
    }
}
