using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class RoomFTimelineTrigger : MonoBehaviour
{
    public PlayableDirector pD;
    public PlayableAsset spiderBitingYou;
    public PlayableAsset spiderDying;
    bool canBePressed;
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other) 
    {
        if (other.tag == "Player")
        {
            // start timeline
            pD.Play();
            StartCoroutine(Wait());
        }
    }

    IEnumerator Wait() {
        {
            // after 5 seconds pause timeline and allow player to interact
           yield return new WaitForSeconds(5);
            //player can interact
           canBePressed = true;
           pD.Pause();
           yield return new WaitForSeconds(2);
            // disable interacton for player
           canBePressed = false;
           pD.Play();
        
        }
    }
    // Update is called once per frame
    void Update()
    {
        // chceck for imput from player
        if (canBePressed)
        {
            // if player pressed interaction button change playable asset to spider dying
            
        }
        
    }
}
