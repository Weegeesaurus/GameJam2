using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClogToilet : MonoBehaviour
{
    public DialogueChain dia;
    // Start is called before the first frame update
    public void clog()
    {
        if (PlayerState.instance.items[6] == true)
        {
            dia.StartDialogue();
            PlayerState.instance.Clogged = true;
        }
    }
}
