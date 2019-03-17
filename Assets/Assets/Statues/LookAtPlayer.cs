using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtPlayer : MonoBehaviour
{
      public GameObject target;
 
    private void Start()
    {
        target = GameObject.FindWithTag("Player");
    }
 
    // Update is called once per frame
    void Update()
    {
        this.gameObject.transform.Rotate(-90,0,0,Space.World);
        transform.LookAt(target.transform);
    }
}
