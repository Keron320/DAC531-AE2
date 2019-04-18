using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorInteractionScript : InteractiveObject
{
    public AnimationClip doorAnimation;
    public bool isOpen = false;
    public override void UseItem()
    {
        if(!canInteract) return;
        if(isOpen) return;
        Debug.Log("Using: " + gameObject.name);
        transform.rotation *= Quaternion.Euler(0.0f, 90.0f, 0.0f);
        //transform.Rotate(new Vector3(0.0f, transform.localRotation.y + -90, 0.0f));
        isOpen = true;
    }
}
