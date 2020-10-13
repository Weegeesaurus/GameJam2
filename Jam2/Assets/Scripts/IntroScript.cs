using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroScript : MonoBehaviour
{
    public IntroDialogue dialogue;
    void Start()
    {
        dialogue.StartDialogue();
    }

    // Update is called once per frame
    public void Complete()
    {
        SceneManager.LoadScene("MainLevel");
    }
}
