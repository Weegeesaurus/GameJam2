using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetItem : MonoBehaviour
{
    public int itemID;
    // Start is called before the first frame update
    public void GrabItem(bool selfDestruct)
    {
        PlayerState.instance.GetItem(itemID);
        if (selfDestruct)
        {
            Destroy(gameObject);
        }
    }
}
