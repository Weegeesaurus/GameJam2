using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class IntroDialogue : MonoBehaviour
{
    public GameObject[] dialogue;
    private int pos=0;
    private GameObject canvas;

    public UnityEvent OnDialogueComplete;

    void Start()
    {
        canvas = GameObject.Find("Canvas");
    }
    public void StartDialogue()
    {
        pos = -1;
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
            CompletedDialogue();
        }
    }
    public void Done()
    {
        PushDialogue();
    }
    private void CompletedDialogue()
    {
        OnDialogueComplete.Invoke();
    }
}
