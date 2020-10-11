using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseKeypad : MonoBehaviour
{
    public GameObject keypad;
    private GameObject canvas;
    // Start is called before the first frame update
    void Start()
    {
        canvas = GameObject.Find("Canvas");
    }

    // Update is called once per frame
    public void OpenKeypad()
    {
        PlayerState.instance.busy = true;
        Cursor.lockState = CursorLockMode.None;
        GameObject pad = Instantiate(keypad, canvas.transform);
        pad.SetActive(true);
        pad.transform.parent = canvas.transform;
    }
}
