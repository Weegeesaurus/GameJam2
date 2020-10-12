using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GarageDoor : MonoBehaviour
{
    public int itemID;
    public DialogueChain dialogue;
    public DialogueChain lockedDia;
    public void UseKey()
    {
        if (PlayerState.instance.items[itemID] == true)
        {
            PlayerState.instance.GarageLock = true;
            lockedDia.StartDialogue();
        }
        else
        {
            dialogue.StartDialogue();
        }
    }
}
