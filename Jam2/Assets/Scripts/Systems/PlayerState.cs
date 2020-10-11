using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : MonoBehaviour
{
    public static PlayerState instance;
    public bool busy = false;
    public bool paused = false;
    public bool PdPower = true;
    public bool HousePower=true;
    public bool[] items;    //11 items
    public Inventory inventory;
    private int PdDelay;
    private GameObject[] Pdlights;
    private GameObject[] PdELights;

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
    public void Start()
    {
        Pdlights = GameObject.FindGameObjectsWithTag("PDLight");
        PdELights = GameObject.FindGameObjectsWithTag("RedLight");
        foreach (GameObject light in PdELights)
        {
            light.SetActive(false);
        }
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

    public void PdPowerOff()
    {
        if (PdPower == true)
        {
            foreach (GameObject light in Pdlights)
            {
                light.SetActive(false);
            }
            foreach (GameObject light in PdELights)
            {
                light.SetActive(true);
            }
            PdPower = false;
            PdDelay = TimeState.instance.getHour()+1;
            InvokeRepeating("updateSec", 1f, 1f);
        }
    }

    public void PowerOn()
    {
        if (HousePower == false)
        {
            foreach (GameObject light in Pdlights)
            {
                light.SetActive(false);
            }
            foreach (GameObject light in PdELights)
            {
                light.SetActive(true);
            }
            PdPower = false;
            PdDelay = TimeState.instance.getHour() + 1;
            InvokeRepeating("updateSec", 1f, 1f);
        }
    }
    private void updateSec()
    {
        if (TimeState.instance.getHour() >= PdDelay)
        {
            foreach (GameObject light in Pdlights)
            {
                light.SetActive(true);
            }
            foreach (GameObject light in PdELights)
            {
                light.SetActive(false);
            }
            PdPower = true;
            CancelInvoke();
        }
    }
}
