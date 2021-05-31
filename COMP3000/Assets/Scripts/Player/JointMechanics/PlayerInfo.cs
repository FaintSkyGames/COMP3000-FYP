using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfo : MonoBehaviour
{
    // Health

    [SerializeField]
    public Inventory inventory;
    private GameObject inventoryUI;


    public PlayerInfo()
    {
        //inventory = new Inventory();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetUpInventoryUI(GameObject UI)
    {
        inventoryUI = UI;
        //inventoryUI.GetComponent<PuzzleInventoryUI>().RefreshInventoryItems(inventory);
        //inventoryUI.GetComponent<PuzzleInventoryUI>().SetInventory(inventory);
    }
}
