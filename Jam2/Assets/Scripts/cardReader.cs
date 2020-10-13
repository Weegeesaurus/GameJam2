using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cardReader : MonoBehaviour
{
    // Start is called before the first frame update
    public doorM door;
    public int itemID;
    public GameObject redSphere;
    public GameObject greenSphere;

    private void Start()
    { 
        redSphere.SetActive(true);
        greenSphere.SetActive(false);
    }
    public void UnlockDoor()
    {
        if (door.IsLocked) {
            door.IsLocked = false;
            door.Open();
            redSphere.SetActive(false);
            greenSphere.SetActive(true);
        }
    }
}
