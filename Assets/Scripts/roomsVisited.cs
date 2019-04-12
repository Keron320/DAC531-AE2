using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class roomsVisited : MonoBehaviour
{

    public bool roomVisitedA = false;
    public bool roomVisitedB = false;
    public bool roomVisitedC = false;
    public bool roomVisitedE = false;
    public bool roomVisitedF = false;

    public GameObject myDoor;

    // Update is called once per frame
    void Update()
    {
        if(roomVisitedA && roomVisitedB && roomVisitedC  && roomVisitedE && roomVisitedF == true)
        {
            // If all conditions are true ( all rooms visited ) enable this doors option to be interactable ( can be used on any doors, first you must disable canInteract though )
            myDoor.GetComponent<DoorInteractionScript>().canInteract = true;
        }
    }
}
