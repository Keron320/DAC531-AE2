using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Statue_Script : MonoBehaviour
{
    // Disable the behaviour when it becomes invisible...
    void OnBecameInvisible()
    {
        enabled = true;
    }

    // ...and enable it again when it becomes visible.
    void OnBecameVisible()
    {
        enabled = false;
    }
}
