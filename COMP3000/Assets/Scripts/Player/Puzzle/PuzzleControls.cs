using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleControls : MonoBehaviour
{
    public PlayerConfiguration playerConfig;
    private Item selectedItem;
    public Inventory inventory;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnChangeTool(string btnName)
    {
        Debug.Log("btn to change pressed - " + btnName);
        Debug.Log("selected before" + inventory.GetSelectedIndex());

        // hard coded
        // need to make changes to allow for remapping
        if (btnName == "1")
        {
            inventory.SetSelectedItem(0);
        }
        else if (btnName == "2")
        {
            inventory.SetSelectedItem(1);
        }
        else if (btnName == "3")
        {
            inventory.SetSelectedItem(2);
        }
        else if (btnName == "4")
        {
            inventory.SetSelectedItem(3);
        }
        else
        {
            inventory.SetSelectedItem(inventory.GetSelectedIndex() + 1);
        }

        Debug.Log("selected after" + inventory.GetSelectedIndex());

    }
}
