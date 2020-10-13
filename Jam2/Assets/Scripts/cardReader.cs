using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cardReader : MonoBehaviour
{
    // Start is called before the first frame update
    public doorM[] doors;
    public int itemID;
    private bool locked;
    public GameObject redSphere;
    public GameObject greenSphere;

    private void Start()
    {
        redSphere.SetActive(true);
        greenSphere.SetActive(false);
        locked = true;
    }
    public void UnlockDoor()
    {
        if (locked && PlayerState.instance.items[itemID]==true)
        {
            foreach (doorM door in doors)
            {
                door.IsLocked = false;
            }
            locked = false;
            redSphere.SetActive(false);
            greenSphere.SetActive(true);
        }
    }
}
