using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class SkullInteractionScript : InteractiveObject
{
    public GameObject subtitleTrigger;

    public override void UseItem()
    {
        // Add the item
        var inventoryManager = GameObject.FindWithTag("Player").GetComponent<InventoryManager>();
        inventoryManager.AddItem(inventoryManager.GetItemByName("Protective Skull"));

        // Display the text from the skull
        gameObject.GetComponent<subTitleTrigger>().StartDisplay();

        // Remove the item from the world       
        for(var i = 0; i < transform.childCount; i++)
        {
            if(transform.GetChild(i).GetComponent<Renderer>() != null)
                transform.GetChild(i).GetComponent<Renderer>().enabled = false;
        }

        enabled = false;
    }
}
