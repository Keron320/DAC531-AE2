using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Statue_Script : MonoBehaviour
{
    // Enable the behaviour when it becomes invisible...
    void OnBecameInvisible()
    {
        GetComponent<LookAtPlayer>().enabled = true;
    }

    // ...and disable it again when it becomes visible.
    void OnBecameVisible()
    {
        GetComponent<LookAtPlayer>().enabled = false;
    }
}
