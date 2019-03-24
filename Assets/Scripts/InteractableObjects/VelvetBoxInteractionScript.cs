using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VelvetBoxInteractionScript : InteractiveObject
{
    public override void UseItem()
    {
        // Add the item
        var inventoryManager = GameObject.FindWithTag("Player").GetComponent<InventoryManager>();
        inventoryManager.AddItem(inventoryManager.GetItemByName("Sharp Stick"));
    }
}
