using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadEnd : MonoBehaviour
{
    // Start is called before the first frame update
    void FixedUpdate()
    {
        if(transform.position.z > -29.5)
        {
            transform.position += transform.forward * Time.deltaTime * 0.25f;
        }
        else
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 90, -90), Time.deltaTime * 2.5f);
        }
    }
}
