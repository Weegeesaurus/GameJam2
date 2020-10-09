using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : MonoBehaviour
{
    public static PlayerState instance;
    public bool busy;
    public bool[] items;    //11 items
    public Inventory inventory;

    private void Awake()    //setting up singleton
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Debug.Log("Instance already exists, destroying object!");
            Destroy(this);
        }
        items = new bool[11];
    }
    public void GetItem(int id)
    {
        items[id] = true;
        inventory.AddInventory(id);
    }

    public void LoseItem(int id)
    {
        if (items[id] == true)
        {
            items[id] = false;
            inventory.RemoveInventory(id);
        }
        else
        {
            Debug.LogWarning("Item not found!");
        }
    }
}
