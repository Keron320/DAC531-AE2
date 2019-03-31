using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameEndScript : MonoBehaviour
{
    // Start is called before the first frame update

    public bool gameWon = false;
    public bool gameLost = false;


    public GameObject win;
    public GameObject lose;


    // To activate in any script of your own
    // Example you have Dracula health < 0;
    //GameObject.Find("GoForScripts").GetComponent<gameEndScript>().gameWon = true;
    // Or "On Trigger enter" Function that just enables this part of the script.


    // Update is called once per frame
    void Update()
    {
        
        if (gameWon == true)
        {
            win.SetActive(true);
            //DOthat
        }

        else if (gameLost == true)
        {
            lose.SetActive(true);
            //DOthat
        }

    }
}
