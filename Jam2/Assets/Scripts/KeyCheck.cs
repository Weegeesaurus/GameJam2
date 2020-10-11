using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyCheck : MonoBehaviour
{
    public PlayerState playerState;
    public doorM door;
    public int itemID;
    public void Unlock()
    {
        if(door.IsLocked)
            if(playerState.items[itemID] == true)
            {
                door.IsLocked = false;
                door.Open();
            }
    }
}
