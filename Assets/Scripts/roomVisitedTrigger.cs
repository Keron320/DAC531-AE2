using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class roomVisitedTrigger : MonoBehaviour
{
    public GameObject roomsVisitedScript;

    public bool iAmRoomA = false;
    public bool iAmRoomB = false;
    public bool iAmRoomC = false;
    public bool iAmRoomE = false;
    public bool iAmRoomF = false;


    private void OnTriggerEnter(Collider other)
    {
        if(iAmRoomA == true)
        roomsVisitedScript.GetComponent<roomsVisited>().roomVisitedA = true;

        if (iAmRoomB == true)
            roomsVisitedScript.GetComponent<roomsVisited>().roomVisitedB = true;

        if (iAmRoomC == true)
            roomsVisitedScript.GetComponent<roomsVisited>().roomVisitedC = true;

        if (iAmRoomE == true)
            roomsVisitedScript.GetComponent<roomsVisited>().roomVisitedE = true;

        if (iAmRoomF == true)
            roomsVisitedScript.GetComponent<roomsVisited>().roomVisitedF = true;
    }

}
