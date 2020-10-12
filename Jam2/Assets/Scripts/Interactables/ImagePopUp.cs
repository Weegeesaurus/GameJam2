using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImagePopUp : MonoBehaviour
{
    [SerializeField] private Image clue;
    private bool on = false;

    void FixedUpdate()
    {
        if (on)
        {
            clue.enabled = true;
            PlayerState.instance.busy = true;

        }
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            on = false;
            clue.enabled = false;
            PlayerState.instance.busy = false;
        }
    }
    public void popUp()
    {
        on = true;
    }

}