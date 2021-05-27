using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PuzzleInventoryUI : MonoBehaviour
{
    private PlayerConfiguration playerConfig;

    //private Inventory inventory;
    private Transform itemSlotContainer;
    private Transform itemSlotTemplate;

    public void Awake()
    {
        itemSlotContainer = transform.Find("Item Slot Container"); 
        itemSlotTemplate = itemSlotContainer.Find("Item Slot Template");
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //public void SetInventory(Inventory inventory)
    //{
    //    this.inventory = inventory;
    //    RefreshInventoryItems();
    //}

    public void RefreshInventoryItems()
    {
        int x = -45;
        int y = 0;
        int itemSlotCellSize = 130;

        foreach (var item in playerConfig.Info.inventory.itemList)
        {
            RectTransform itemSlotRectTransform = Instantiate(itemSlotTemplate, itemSlotContainer).GetComponent<RectTransform>();
            itemSlotRectTransform.gameObject.SetActive(true);
            itemSlotRectTransform.anchoredPosition = new Vector2(x + itemSlotCellSize, y);
            itemSlotRectTransform.Find("Image").GetComponent<Image>().sprite = item.GetSprite();
            x += itemSlotCellSize;
        }
    }

    public void BindToPlayer(PlayerConfiguration pc)
    {
        playerConfig = pc;
        RefreshInventoryItems();
    }
}
