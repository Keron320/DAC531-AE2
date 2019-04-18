using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIHealthController : MonoBehaviour {

    
    private GameObject myPlayer;        // Finds the player gameobject
    public  GameObject prefabToSpawn; // what image to spawn
    public string parentLocation; // Under where the object is spawned

    GameObject heartsUI;

    public int playerHealth;    // Gets the player health from the GO
    public int playerSanity; // gets the player sanity from the GO

    public int playerIntelligence; 
    public int playerPerception;
    public int playerStrength;
    public int playerWillpower;
    public int playerAgility;
    public int playerCharisma;


    public bool iAmHealth = false;
    public bool iAmSanity = false;
    public bool iAmIntelligence = false;
    public bool iAmPerception = false;
    public bool iAmStrength = false;
    public bool iAmWillpower = false;
    public bool iAmAgility = false;
    public bool iAmCharisma = false;


    public List<GameObject> health = new List<GameObject>();    //List of hearts

    // Use this for initialization
    void Awake () {
        myPlayer = GameObject.Find("Character");   // Find the player to get the amount of health from
}
    private void Start()
    {
        // Starting hearts
        playerHealth = myPlayer.GetComponent<PlayerController>().playerStats.health;
        playerSanity = myPlayer.GetComponent<PlayerController>().playerStats.sanity;
        playerIntelligence = myPlayer.GetComponent<PlayerController>().playerStats.inteligence;
        playerPerception = myPlayer.GetComponent<PlayerController>().playerStats.perception;
        playerStrength = myPlayer.GetComponent<PlayerController>().playerStats.strength;
        playerWillpower = myPlayer.GetComponent<PlayerController>().playerStats.willpower;
        playerAgility = myPlayer.GetComponent<PlayerController>().playerStats.agility;
        playerCharisma = myPlayer.GetComponent<PlayerController>().playerStats.charisma;

        if (iAmHealth == true)
        {
            // I was hoping to find a better way of doing this.. like having to only change playerHealth but had no idea how... So i made if statements......
            while (health.Count < playerHealth)
            {
                addUnit();
            }
        }

        else if (iAmSanity == true)
        {
            while (health.Count < playerSanity)
            {
                addUnit();
            }
        }


        else if (iAmIntelligence == true)
        {
            while (health.Count < playerIntelligence)
            {
                addUnit();
            }
        }


        else if (iAmPerception == true)
        {
            while (health.Count < playerPerception)
            {
                addUnit();
            }
        }


        else if (iAmWillpower == true)
        {
            while (health.Count < playerWillpower)
            {
                addUnit();
            }
        }


        else if (iAmCharisma == true)
        {
            while (health.Count < playerCharisma)
            {
                addUnit();
            }
        }

        else if (iAmStrength == true)
        {
            while (health.Count < playerStrength)
            {
                addUnit();
            }
        }

        else if (iAmAgility == true)
        {
            while (health.Count < playerAgility)
            {
                addUnit();
            }
        }
    }

    void addUnit()
    {
    //   if (hearts.Count < playerHealth)
    //   {
            GameObject heartsUI = Instantiate(prefabToSpawn) as GameObject; //Spawn prefab
            heartsUI.transform.parent = GameObject.Find(parentLocation).transform; // Spawn it as a child for the Panel
            health.Add(heartsUI); //Add the spawned object into a list
    //    }
    }

    void removeUnit()
    {
        //    if (hearts.Count > playerHealth)
        //    {
        GameObject lastHeart = health[health.Count - 1];
        health.Remove(lastHeart); //Add the spawned object into a list
        Destroy(lastHeart);
        //    }
    }

    // Update is called once per frame
    void Update() {
        //Keep an update on playerhealth at all times
        playerHealth = myPlayer.GetComponent<PlayerController>().playerStats.health;

        if (health.Count > playerHealth)
        {
            removeUnit();
        }
    }



}