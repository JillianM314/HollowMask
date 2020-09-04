using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Slot : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{

    private bool hovered;
    public bool empty;

    public GameObject item;
    public Texture itemIcon;

    private GameObject player;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        hovered = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (item)
        {
            empty = false;

            itemIcon = item.GetComponent<Item>().icon;
            this.GetComponent<RawImage>().texture = itemIcon;
        }
        else
        {
            empty = true;
            itemIcon = null;
            this.GetComponent<RawImage>().texture = null;
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        hovered = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        hovered = false;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (item)
        {
            Item thisItem = item.GetComponent<Item>();

            if (thisItem.type == "healthItem")
            {
              //Add in win later
                Destroy(item);
            }
        }
    }
}
