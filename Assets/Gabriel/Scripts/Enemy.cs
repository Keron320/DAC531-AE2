using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health;


    private void Update()
    {
        //check for health and die if necessary 
    }
    public void dealDmg(int dmg)
    {
        if(health>=0)
            health -= dmg;
    }
}
