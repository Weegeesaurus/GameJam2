using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamInteract : MonoBehaviour
{
    private bool tape = false;
    private bool used = false;

    public GameObject screen0;
    public GameObject screen1;
    public GameObject screen2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void Interact()
    {
        if (tape)
        {
            if (!used)
            {
                if (PlayerState.instance.canRecord == true)
                {
                    PlayerState.instance.raid = true;
                }
                screen1.SetActive(false);
                screen2.SetActive(true);
            }
        }
        else
        {
            if (PlayerState.instance.items[8]==true)
            {
                tape = true;
                screen0.SetActive(false);
                screen1.SetActive(true);
            }
            else
            {
                //error noises
            }
        }
    }
}
