using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
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
        }
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            on = false;
            clue.enabled = false;
        }
    }
    public void popUp()
    {
        on = true;
        
    }

}
