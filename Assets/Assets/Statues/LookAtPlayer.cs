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
        transform.LookAt(new Vector3(target.transform.position.x, transform.position.y, target.transform.position.z));
        transform.Rotate(180, transform.rotation.y, transform.rotation.z);
    }
}
