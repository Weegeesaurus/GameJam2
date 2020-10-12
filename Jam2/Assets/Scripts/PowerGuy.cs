using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerGuy : MonoBehaviour
{
    // Start is called before the first frame update
    public MoveAI moveAi;
    public GameObject dialogueObj;
    void Start()
    {
        InvokeRepeating("updateSec", 1f, 1f);
    }
    private void updateSec()
    {
        if (PlayerState.instance.PdPower == true)
        {
            dialogueObj.SetActive(true);
            moveAi.SetDestination(0);
        }
        else
        {
            dialogueObj.SetActive(false);
            moveAi.SetDestination(1);
        }
    }
}
