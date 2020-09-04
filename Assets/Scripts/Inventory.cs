using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public GameObject playerInventory;

    public GameObject slotHolder;
    public GameObject itemManager;
    private bool playerInventoryEnabled;

    private int slots;
    public Transform[] slot;

    private GameObject itemPickedUp;
    private bool itemAdded;

    // Start is called before the first frame update
    void Start()
    {
        playerInventoryEnabled = true;
        slots = slotHolder.transform.childCount;
        slot = new Transform[slots];
        DetectInventorySlots();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            playerInventoryEnabled = !playerInventoryEnabled;
        }

        if (playerInventoryEnabled)
        {
            playerInventory.GetComponent<Canvas>().enabled = true;

            ShowMouseCursor();
        }
        else
        {
            playerInventory.GetComponent<Canvas>().enabled = false;

            HideMouseCursor();
        }
    }

    public void OnTriggerEnter(Collider other)
    {

        if (other.tag == "item" || other.tag == "healthItem")
        {
            print("Collided with: " + other.gameObject.name);
            itemPickedUp = other.gameObject;
            AddItem(itemPickedUp);

        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.tag == "item" || other.tag == "healthItem")
        {
            itemAdded = false;
        }
    }

    public void AddItem(GameObject item)
    {

        Debug.Log("Trying to add: " + item.name);

        for (int i = 0; i < slots; i++)
        {
            if (slot[i].GetComponent<Slot>())
            {

                if (slot[i].GetComponent<Slot>().item == null && item.tag == "item") //&&itemAdded == false
                {
                    slot[i].GetComponent<Slot>().item = item;
                    slot[i].GetComponent<Slot>().itemIcon = item.GetComponent<Item>().icon;

                    if (item.GetComponent<MeshRenderer>())
                    {
                        item.GetComponent<MeshRenderer>().enabled = false;
                        item.GetComponent<BoxCollider>().enabled = false;
                    }

                    item.transform.parent = itemManager.transform;
                    item.transform.position = itemManager.transform.position;

                    //itemAdded = true;
                    break;
                }

            }
            else if (slot[i].GetComponent<HealthSlot>())
            {
                Debug.Log("You picked up health");
                if (slot[i].GetComponent<HealthSlot>().healthItem == null && item.tag == "healthItem")
                {
                    slot[i].GetComponent<HealthSlot>().healthItem = item;
                    slot[i].GetComponent<HealthSlot>().itemIcon = item.GetComponent<HealthItem>().icon;

                    if (item.GetComponent<MeshRenderer>())
                    {
                        item.GetComponent<MeshRenderer>().enabled = false;
                        item.GetComponent<BoxCollider>().enabled = false;
                    }

                    item.transform.parent = itemManager.transform;
                    item.transform.position = itemManager.transform.position;

                    //itemAdded = true;
                    break;
                }

            }

        }
    }

    void DetectInventorySlots()
    {
        playerInventory.GetComponent<Canvas>().enabled = true;


        for (int i = 0; i < slots; i++)
        {
            slot[i] = slotHolder.transform.GetChild(i);
        }

        playerInventoryEnabled = false;
    }

    public void ShowMouseCursor()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void HideMouseCursor()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
}
