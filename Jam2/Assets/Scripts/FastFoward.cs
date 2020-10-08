using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FastFoward : MonoBehaviour
{
    public Image img;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            TimeState.instance.minutesPerSecond = 10;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            TimeState.instance.minutesPerSecond = 2;
        }
    }
}
