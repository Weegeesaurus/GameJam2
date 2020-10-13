using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoodEndd : MonoBehaviour
{
    // Update is called once per frame
    private bool hands = false;
    void Start()
    {
        Invoke("HandsUp",9f);
    }
    void FixedUpdate()
    {
        if(hands)
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(-90, -32, 0), Time.deltaTime * 1f);
    }
    void HandsUp()
    {
        hands = true;
    }
}
