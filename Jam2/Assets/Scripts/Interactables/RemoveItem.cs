using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveItem : MonoBehaviour
{
    public int itemID;
    // Start is called before the first frame update
    public void LoseItem()
    {
        PlayerState.instance.LoseItem(itemID);
    }
}
