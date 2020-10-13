using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyCheck : MonoBehaviour
{
    public doorM door;
    public int itemID;
    public void Unlock()
    {
        if(door.IsLocked)
            if(PlayerState.instance.items[itemID] == true)
            {
                door.IsLocked = false;
                door.Open();
            }
            else
            {
                GameObject obj = Instantiate(PlayerState.instance.LockedSound);
                Destroy(obj, 4f);
            }
    }
}
