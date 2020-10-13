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
    public bool Clogged=false;
    public bool GarageLock=false;
    public bool raid=false;
    public bool canRecord=false;
    public bool[] items;    //11 items
    public Inventory inventory;

    public GameObject PowerOutSound;
    public GameObject PowerOnSound;
    public GameObject CrashSound;
    public GameObject GunSound;
    public GameObject LockedSound;
    public GameObject KnockSound;
    public GameObject SirenSound;
    public GameObject ErrorSound;
    public GameObject SuccessSound;
    private int PdDelayH;
    private int PdDelayM;
    private GameObject[] Pdlights;
    private GameObject[] PdELights;
    private GameObject[] HouseLights;
    private GameObject[] HELights;
    private GameObject[] raidDoors;

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
        HouseLights = GameObject.FindGameObjectsWithTag("HouseLight");
        HELights = GameObject.FindGameObjectsWithTag("BlueLight");
        raidDoors = GameObject.FindGameObjectsWithTag("RaidDoor");
        foreach (GameObject light in PdELights)
        {
            light.SetActive(false);
        }
        foreach (GameObject light in HELights)
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

    public void Raid()
    {
        GameObject obj = Instantiate(SirenSound);
        Destroy(obj, 15f);
        foreach (GameObject door in raidDoors)
        {
            doorM component = door.GetComponent<doorM>();
            component.IsLocked = false;
            component.Open();
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
            GameObject obj = Instantiate(PowerOutSound);
            PdDelayH = TimeState.instance.getHour()+1;
            PdDelayM = TimeState.instance.getMinute();
            InvokeRepeating("updateSec", 1f, 1f);
        }
    }

    public void PowerOff()
    {
        if (HousePower == true)
        {
            foreach (GameObject light in HouseLights)
            {
                light.SetActive(false);
            }
            foreach (GameObject light in HELights)
            {
                light.SetActive(true);
            }
            GameObject obj =Instantiate(PowerOutSound);
            Destroy(obj, 10f);
            HousePower = false;
        }
    }
    public void PowerOn()
    {
        if (HousePower == false)
        {
            foreach (GameObject light in HouseLights)
            {
                light.SetActive(true);
            }
            foreach (GameObject light in HELights)
            {
                light.SetActive(false);
            }
            GameObject obj = Instantiate(PowerOnSound);
            Destroy(obj, 10f);
            HousePower = true;
        }
    }
    public void Crash()
    {
        GameObject obj = Instantiate(CrashSound);
        Destroy(obj, 10f);
    }
    public void Gunshot()
    {
        GameObject obj = Instantiate(GunSound);
        Destroy(obj, 10f);
    }
    private void updateSec()
    {
        if (TimeState.instance.getHour() >= PdDelayH && TimeState.instance.getMinute() >= PdDelayM)
        {
            foreach (GameObject light in Pdlights)
            {
                light.SetActive(true);
            }
            foreach (GameObject light in PdELights)
            {
                light.SetActive(false);
            }
            GameObject obj = Instantiate(PowerOnSound);
            PdPower = true;
            CancelInvoke();
        }
    }
}
