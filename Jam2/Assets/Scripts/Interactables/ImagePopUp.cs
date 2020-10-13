using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using UnityEngine;
using UnityEngine.UI;

public class ImagePopUp : MonoBehaviour
{
    [SerializeField] private GameObject clue;
    private bool on = false;

    void Update()
    {
        if (on)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                on = false;
                clue.SetActive(false);
                PlayerState.instance.busy = false;
            }
        }
    }
    public void popUp()
    {
        on = true;
        clue.SetActive(true);
        PlayerState.instance.busy = true;
    }
    
}
