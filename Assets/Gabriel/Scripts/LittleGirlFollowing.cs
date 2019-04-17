using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using PixelCrushers.DialogueSystem;


public class LittleGirlFollowing : MonoBehaviour
{
    GameObject Player;
    NavMeshAgent agent;
    Animator anim;
    Vector3 lastPosition;

    bool startFollowing=false;
    bool coroutining = false;

    void Start()
    {
        Player = GameObject.Find("Character (1)").transform.gameObject;
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();

        agent.autoBraking = false;

        lastPosition = Player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        print(agent.remainingDistance);
        if (startFollowing && !coroutining && lastPosition != Player.transform.position)
        {
            StartCoroutine(startWalking());
            coroutining = true;
        }

        if (agent.remainingDistance <= 2.5f)
        {
            agent.velocity = Vector3.zero;
            agent.isStopped = false;
            anim.SetFloat("speed", 0);
        }


    }

    public void StartFollow()
    {
        startFollowing = true;
    }

    public void stopCrying()
    {
        StartCoroutine(destroyCryingSound());
        anim.SetBool("cry", false);
    }

    IEnumerator destroyCryingSound()
    {
        yield return new WaitForSeconds(0.5f);
        if(GameObject.Find("Girl Crying Source").gameObject)
              Destroy(GameObject.Find("Girl Crying Source").transform.gameObject);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.gameObject == Player)
            Physics.IgnoreCollision(GetComponent<Collider>(), collision.transform.GetComponent<Collider>());
    }

    IEnumerator startWalking()
    {
        yield return new WaitForSeconds(1);
        agent.SetDestination(Player.transform.position);
        lastPosition = Player.transform.position;
        anim.SetFloat("speed", 1);
        coroutining=false;

    }
}
