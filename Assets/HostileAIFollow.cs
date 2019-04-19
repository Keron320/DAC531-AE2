using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class HostileAIFollow : MonoBehaviour
{
    public GameObject gameobject;
    GameObject Player;
    NavMeshAgent agent;
    Animator anim;
    Animator playerAnim;
    public RuntimeAnimatorController animatorController;
    Vector3 lastPosition;

    public bool startFollowing = false;
    bool happened = false;
    bool jake = false, sam = false, mario = false;
    public float maxDistance;
    RaycastHit hit;

    void Start()
    {
        Player = GameObject.Find("Character (1)").transform.gameObject;
        playerAnim = Player.transform.GetChild(1).GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();

        agent.autoBraking = false;

        lastPosition = Player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(transform.position + new Vector3(0, 1, 0), transform.TransformDirection(Vector3.forward) * maxDistance, Color.blue);
        Debug.DrawRay(transform.position + new Vector3(0, 1, 0), (transform.TransformDirection(Vector3.forward) + new Vector3(1, 0, 0)) * maxDistance, Color.blue);
        Debug.DrawRay(transform.position + new Vector3(0, 1, 0), (transform.TransformDirection(Vector3.forward) + new Vector3(-1, 0, 0)) * maxDistance, Color.blue);
                                                          
        // Does the ray intersect any objects excluding the player layer
        if (Physics.Raycast(transform.position+ new Vector3(0,1,0), transform.TransformDirection(Vector3.forward), out hit,maxDistance)||
            Physics.Raycast(transform.position + new Vector3(0, 1, 0), (transform.TransformDirection(Vector3.forward)+new Vector3(1,0,0)), out hit, maxDistance)||
            Physics.Raycast(transform.position + new Vector3(0, 1, 0), (transform.TransformDirection(Vector3.forward) + new Vector3(-1, 0, 0)), out hit, maxDistance))
        {
            if(hit.transform.CompareTag("Player") && hit.transform.GetComponent<PlayerController>().playerStats.health > 0)
            {

                agent.velocity = Vector3.zero;
                agent.isStopped = false;
                anim.SetBool("isWalking", false);
                if (!happened)
                {
                    happened = !happened;
                    anim.SetBool("isAttacking", true);
                    StartCoroutine(stopAttacking());
                }
            }
            if(hit.transform.name=="sam")
            {

                agent.velocity = Vector3.zero;
                agent.isStopped = false;
                anim.SetBool("isWalking", false);
                if (!happened)
                {
                    happened = !happened;
                    anim.SetBool("isBiting", true);
                    StartCoroutine(stopBiting());
                }

            }
        }
        else if(startFollowing)
        {
            agent.SetDestination(gameobject.transform.position);
            lastPosition = gameobject.transform.position;
            anim.SetBool("isWalking", true);
            transform.LookAt(agent.steeringTarget);
        }


    }

    public void StartFollow()
    {
        startFollowing = true;
    }
    
    IEnumerator stopAttacking()
    {
        yield return new WaitForSeconds(0.1f);
        anim.SetBool("isAttacking", false);

        yield return new WaitForSeconds(1);
        if (Physics.Raycast(transform.position + new Vector3(0, 1, 0), transform.TransformDirection(Vector3.forward), out hit, maxDistance) ||
            Physics.Raycast(transform.position + new Vector3(0, 1, 0), (transform.TransformDirection(Vector3.forward) + new Vector3(1, 0, 0)), out hit, maxDistance) ||
            Physics.Raycast(transform.position + new Vector3(0, 1, 0), (transform.TransformDirection(Vector3.forward) + new Vector3(-1, 0, 0)), out hit, maxDistance))
        {
            if (hit.transform.CompareTag("Player") )
            {
                if (Player.GetComponent<PlayerController>().playerStats.health >= 0)
                {
                    Player.GetComponent<PlayerController>().playerStats.health -= Random.RandomRange(1, 4);
                    playerAnim.SetBool("hurt", true);
                    StartCoroutine(stopPlayerHurtAnimation());
                }
                if(Player.GetComponent<PlayerController>().playerStats.health <= 0)
                {
                    playerAnim.SetBool("dead", true);
                    Player.GetComponent<PlayerController>().enabled = false;
                    Player.GetComponent<AudioSource>().enabled = false;
                }
            }
        }
        yield return new WaitForSeconds(2.5f);
        happened = !happened;
    }

    IEnumerator stopBiting()
    {
        yield return new WaitForSeconds(0.1f);
        anim.SetBool("isBiting", false);

        Destroy(hit.transform.gameObject.GetComponent<NPCmovement>());
        hit.transform.gameObject.GetComponent<Animator>().runtimeAnimatorController = animatorController;
        hit.transform.gameObject.AddComponent<HostileAIFollow>();
        hit.transform.gameObject.AddComponent<Enemy>();
        hit.transform.gameObject.GetComponent<HostileAIFollow>().maxDistance = 2;
        hit.transform.gameObject.GetComponent<Enemy>().health = 10;
        hit.transform.gameObject.GetComponent<HostileAIFollow>().gameobject = Player;
        hit.transform.gameObject.GetComponent<HostileAIFollow>().startFollowing = true;
        sam = true;

        yield return new WaitForSeconds(0.5f);
        anim.SetBool("isWalking", true);

    }

    IEnumerator stopPlayerHurtAnimation()
    {
        yield return new WaitForSeconds(1.76f);
        playerAnim.SetBool("hurt", false);
    }
}
