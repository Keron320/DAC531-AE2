using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DealDmg : MonoBehaviour
{
    GameObject target;
    Animator targetAnim;
    Animator anim;
    RaycastHit hit;

    public float maxDistance;

    // Start is called before the first frame update
    void Start()
    {
        anim =transform.GetChild(1).GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(transform.position + new Vector3(0, 1, 0), transform.TransformDirection(Vector3.forward) * maxDistance, Color.blue);

        if (Physics.Raycast(transform.position + new Vector3(0, 1, 0), transform.TransformDirection(Vector3.forward), out hit, maxDistance) && Input.GetMouseButtonDown(0))
        {
            //get target references (any enemy)
            target = hit.transform.gameObject;
            targetAnim = target.GetComponent<Animator>();
            if (target.GetComponent<Enemy>().health >= 0)
            {
                //cast attack animation + deal dmg
                anim.SetBool("attack", true);
                StartCoroutine(stopAttackAnimation());

                target.GetComponent<Enemy>().dealDmg(Random.RandomRange(1, 5));
            }
            if (target.GetComponent<Enemy>().health <= 0 && target.CompareTag("Dracula"))
            {
                targetAnim.SetBool("isDeadStab", true);
                StartCoroutine(stopDraculaDeathStab());
            }
            else if(target.GetComponent<Enemy>().health <= 0 && target.CompareTag("NPC"))
            {
                targetAnim.SetBool("isDead", true);
                StartCoroutine(stopDeathAnim());
                
            }

        }
    }

    IEnumerator playHurtAnim()
    {
        yield return new WaitForSeconds(1f);
        targetAnim.SetBool("isHit", false);
    }
    IEnumerator stopDeathAnim()
    {
        yield return new WaitForSeconds(2.9f);
        targetAnim.SetBool("isDead", false);
        Destroy(target.gameObject);
    }
    IEnumerator stopAttackAnimation()
    {
        //wait mid of the player attack animation to play enemy hurt animation
        yield return new WaitForSeconds(1);
        targetAnim.SetBool("isHit", true);
        if (target.CompareTag("Dracula"))
            StartCoroutine(stopDraculaHurtAnimation());
        else StartCoroutine(stopNpcHurtAnimation());

        //end player attack animation
        yield return new WaitForSeconds(2f);
        anim.SetBool("attack", false);
    }
    IEnumerator stopNpcHurtAnimation()
    {
        //set it false immediately 
        yield return new WaitForSeconds(0.2f);
        targetAnim.SetBool("isHit", false);
        targetAnim.SetBool("isIdle", true);

    }

    IEnumerator stopDraculaHurtAnimation()
    {
        //set it false immediately 
        yield return new WaitForSeconds(0.1f);
        targetAnim.SetBool("isHit", false);
        targetAnim.SetBool("isIdle", true);

    }

    IEnumerator stopDraculaDeathStab()
    {
        yield return new WaitForSeconds(0.1f);
        targetAnim.SetBool("isDeadStab", false);
        Destroy(target.gameObject);
    }
}
