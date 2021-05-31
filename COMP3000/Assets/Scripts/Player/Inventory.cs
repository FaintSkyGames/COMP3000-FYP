using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<Item> itemList;
    private int selectedItem = 0;

    public event EventHandler OnInventoryChanged;

    public Inventory()
    {
        itemList = new List<Item>();

        //AddItem(new Item { itemType = Item.ItemType.puzzlePiece, amount = 1});
        //AddItem(new Item { itemType = Item.ItemType.ammo, amount = 1 });
        //AddItem(new Item { itemType = Item.ItemType.puzzlePiece, amount = 1 });
        //AddItem(new Item { itemType = Item.ItemType.health, amount = 1 });
    }

    public void AddItem(Item item)
    {
        itemList.Add(item);

        OnInventoryChanged?.Invoke(this, EventArgs.Empty);
    }

    public List<Item> GetItemList()
    {
        return itemList;
    }

    public void SetSelectedItem(int selectedIndex)
    {
        Debug.Log("selected item changed");

        selectedItem = selectedIndex;

        if (selectedItem > itemList.Count - 1)
        {
            selectedItem = 0;
        }

        if (selectedItem == 4)
        {
            selectedItem = 0;
        }

        

        OnInventoryChanged(this, EventArgs.Empty);        
    }

    public int GetSelectedIndex()
    {
        return selectedItem;
    }


}
