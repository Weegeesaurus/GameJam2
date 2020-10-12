using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbCheck : MonoBehaviour
{
    public PlayerState playerState;
    public OfficePAths guy;
    public int itemID;
    public void Unlock()
    {
        if(playerState.items[itemID] == true)
        {
            guy.Skip();
            Destroy(gameObject);
        }
    }
}
