using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardOrbCheck : MonoBehaviour
{
   public PlayerState playerState;
    public MoveAI moveAi;
    public DialogueChain dialogueBefore;
    public DialogueChain dialogueAfter;
    public int itemID;
    public void Unlock()
    {
        if(TimeState.instance.getHour() >= 20)
            if(playerState.items[itemID] == true)
            {
                moveAi.SetDestination(0);
                Destroy(gameObject);
            }
            else
                dialogueAfter.StartDialogue();
        else
            dialogueBefore.StartDialogue();
    }
}
