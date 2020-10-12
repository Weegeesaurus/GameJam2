using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerGuy : MonoBehaviour
{
    // Start is called before the first frame update
    public MoveAI moveAi;
    void Start()
    {
        InvokeRepeating("updateSec", 1f, 1f);
    }
    private void updateSec()
    {
        if (PlayerState.instance.PdPower == true)
            moveAi.SetDestination(0);
        else
            moveAi.SetDestination(1);
    }
}
