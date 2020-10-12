using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueChain : MonoBehaviour
{
    public GameObject[] dialogue;
    private int pos=0;
    private GameObject canvas;

    void Start()
    {
        canvas = GameObject.Find("Canvas");
    }
    public void StartDialogue()
    {
        pos = -1;
        PlayerState.instance.busy = true;
        PushDialogue();
    }

    // Update is called once per frame
    void PushDialogue()
    {
        pos++;
        if (pos<dialogue.Length)
        {
            GameObject dia = Instantiate(dialogue[pos],canvas.transform);
            dia.SetActive(true);
            dia.GetComponent<TextScroll>().SetOwner(gameObject);
            dia.transform.SetParent(canvas.transform);
        }
        else
        {
            PlayerState.instance.busy = false;
        }
    }
    public void Done()
    {
        PushDialogue();
    }
}
