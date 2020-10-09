using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using UnityEngine;

public class FlyOnClick : MonoBehaviour
{
    public float flyspeed = 3;
    private bool on = false;
    void FixedUpdate()
    {
        if (on)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y+flyspeed * Time.deltaTime, transform.position.z);
        }
    }
    public void flyaway()
    {
        on = true;
        Destroy(gameObject,6f);
    }
}
