using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelDoorInteractionScript : InteractiveObject
{
    public GameObject nextScene;
    public GameObject previousScene;
    public Transform  spawnPosition;

    public override void UseItem()
    {
        if (!canInteract) return;
        nextScene.SetActive(true);
        GameObject.Find("Player").transform.position = spawnPosition.position;
        previousScene.SetActive(false);
    }
}
