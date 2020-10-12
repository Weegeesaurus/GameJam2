using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ownerAI : MonoBehaviour
{
    public MoveAI moveAi;
    public DialogueChain none;
    public DialogueChain power;
    public DialogueChain tp;

    // Update is called once per frame
    public void talk()
    {
        if (PlayerState.instance.Clogged==true)
        {
            moveAi.SetDestination(0);
            tp.StartDialogue();
            Destroy(gameObject);
        }
        else if (PlayerState.instance.HousePower == false)
        {
            power.StartDialogue();
        }
        else
        {
            none.StartDialogue();
        }
    }
}
