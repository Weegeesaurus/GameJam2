using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardOrbCheck : MonoBehaviour
{
    public MoveAI moveAi;
    public DialogueChain dialogueBefore;
    public DialogueChain dialogueAfter;
    public BoxCollider panalCollider;
    public SphereCollider selfCollider;
    public int itemID;
    public void Unlock()
    {
        if(TimeState.instance.getHour() >= 20)
            if(PlayerState.instance.items[itemID] == true)
            {
                moveAi.SetDestination(0);
                Destroy(gameObject);
                panalCollider.isTrigger = true;
                selfCollider.isTrigger = true;
            }
            else
                dialogueAfter.StartDialogue();
        else
            dialogueBefore.StartDialogue();
    }
}
