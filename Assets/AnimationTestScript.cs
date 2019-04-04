using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationTestScript : MonoBehaviour
{
    // Start is called before the first frame update
    private Animator MyAnim;

    public bool standUpAnim = false;
    // Idle can be always true, so when one action ends it will always go back to idle
    public bool idleAnim = true;
    public bool hitAnim = false;
    public bool attackAni   = false;
    public bool deadFireAnim = false;
    public bool deadStabAnim = false;
    public bool biteMe = false;

    void Start()
    {
        MyAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        // Make sure you double click the tick boxes to "activate the animation once" otherwise it keeps activating it 60+ times per second and that will result a jagged animation ( infinite too )
        // You can use this script as a reference in setting up it with the AI.

        if(standUpAnim == true)
        MyAnim.SetBool("standUp", true);
        else
        MyAnim.SetBool("standUp", false);
        // 1

        if (idleAnim == true)
            MyAnim.SetBool("isIdle", true);
        else
            MyAnim.SetBool("isIdle", false);
        // 2 

        if (hitAnim == true)
            MyAnim.SetBool("isHit", true);
        else
            MyAnim.SetBool("isHit", false);
        // 3 

        if (attackAni == true)
            MyAnim.SetBool("isAttacking", true);
        else
            MyAnim.SetBool("isAttacking", false);
        // 4

        if (deadFireAnim == true)
            MyAnim.SetBool("isDeadFire", true);
        else
            MyAnim.SetBool("isDeadFire", false);
        // 5

        if (deadStabAnim == true)
            MyAnim.SetBool("isDeadStab", true);
        else
            MyAnim.SetBool("isDeadStab", false);


        if (biteMe == true)
            MyAnim.SetBool("isBiting", true);
        else
            MyAnim.SetBool("isBiting", false);
    }
}
