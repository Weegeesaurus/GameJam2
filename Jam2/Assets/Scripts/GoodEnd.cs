using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoodEnd : MonoBehaviour
{
    void FixedUpdate()
    {
        if(transform.position.z > -29.5)
        {
            transform.position += transform.forward * Time.deltaTime * 0.25f;
        }
}
}
