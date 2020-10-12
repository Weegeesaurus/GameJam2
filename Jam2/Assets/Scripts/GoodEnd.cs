using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class GoodEnd : MonoBehaviour
{
    public DialogueChain dialogueChain;
    private bool speach = false;
    void FixedUpdate()
    {
        if(transform.position.z > -29.5)
        {
            transform.position += transform.forward * Time.deltaTime * 0.25f;
            if(!speach)
            {
                dialogueChain.StartDialogue();
                speach = true;
            }
        }
    }
}