using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PuzzleInventoryUI : MonoBehaviour
{
    private GameObject player;

    //private Inventory inventory;
    private Transform itemSlotContainer;
    private Transform itemSlotTemplate;
    private Transform itemSelectedIcon;

    public void Awake()
    {
        itemSlotContainer = transform.Find("Item Slot Container"); 
        itemSlotTemplate = itemSlotContainer.Find("Item Slot Template");
        itemSelectedIcon = itemSlotContainer.Find("Selected");
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetInventory(Inventory inventory)
    {
        RefreshInventoryItems();
    }

    public void RefreshInventoryItems()
    {
        foreach( Transform child in itemSlotContainer)
        {
            if (child != itemSlotTemplate && child != itemSelectedIcon)
            {
                Destroy(child.gameObject);
            }

        }

        int x = -45;
        int y = 0;
        int itemSlotCellSize = 130;

        foreach (var item in player.GetComponent<Inventory>().itemList)
        {
            RectTransform itemSlotRectTransform = Instantiate(itemSlotTemplate, itemSlotContainer).GetComponent<RectTransform>();
            itemSlotRectTransform.gameObject.SetActive(true);
            itemSlotRectTransform.anchoredPosition = new Vector2(x + itemSlotCellSize, y);
            itemSlotRectTransform.Find("Image").GetComponent<Image>().sprite = item.GetSprite();
            x += itemSlotCellSize;
        }

        RectTransform selectedRectTransform = itemSelectedIcon.GetComponent<RectTransform>();
        if (player.GetComponent<Inventory>().GetSelectedIndex() != -1)
        {            
            selectedRectTransform.gameObject.SetActive(true);
            int position = -45 + ((player.GetComponent<Inventory>().GetSelectedIndex() + 1) * itemSlotCellSize);
            selectedRectTransform.anchoredPosition = new Vector2(position, y);
            itemSelectedIcon.SetAsLastSibling(); // Ensure always seen on top of other graphics
        }
        else
        {
            selectedRectTransform.gameObject.SetActive(false);
        }
    }

    public void BindToPlayer(GameObject pc)
    {
        player = pc;
        player.GetComponent<Inventory>().OnInventoryChanged += Inventory_OnInventoryChanged;
        RefreshInventoryItems();
    }

    private void Inventory_OnInventoryChanged(object sender, System.EventArgs e)
    {
        Debug.Log("Recieved on change");
        RefreshInventoryItems();
    }
}
