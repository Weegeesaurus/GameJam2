using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public Sprite[] icons;
    private List<GameObject> inventory;
    public GameObject BaseItem;
    public float padding;
    void Start()
    {
        inventory = new List<GameObject>();
    }

    // Update is called once per frame
    public void AddInventory(int item)
    {
        GameObject newItem = Instantiate(BaseItem,gameObject.transform);
        newItem.GetComponent<Image>().sprite = icons[item];
        newItem.SetActive(true);
        inventory.Add(newItem);
        UpdateInventory();
    }

    public void RemoveInventory(int item)
    {
        foreach (GameObject obj in inventory)
        {
            if (obj.GetComponent<Image>().sprite == icons[item])
            {
                inventory.Remove(obj);
                UpdateInventory();
                Destroy(obj);
                return;
            }
        }
    }
    private void UpdateInventory()
    {
        int i=0;
        foreach (GameObject item in inventory)
        {
            item.GetComponent<RectTransform>().position = new Vector3(gameObject.transform.position.x+i * padding, gameObject.transform.position.y, gameObject.transform.position.z);
            i++;
        }
    }
}
