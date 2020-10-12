using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbCheck : MonoBehaviour
{
    public PlayerState playerState;
    public MoveAI moveAi;
    public DialogueChain dialogue;
    public int itemID;
    void Start()
    {
        InvokeRepeating("updateSec", 1f, 1f);
    }
    private void updateSec()
    {
        if (TimeState.instance.getHour() >= 19)
        {
            moveAi.SetDestination(1);
        }
    }
    public void Unlock()
    {
        if(playerState.items[itemID] == true)
        {
            moveAi.SetDestination(0);
            Destroy(gameObject);
        }else
        {
            dialogue.StartDialogue();
        }
    }


}
