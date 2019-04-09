using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DraculaBurnScript : MonoBehaviour
{
   public ParticleSystem[] particles;
   public Material[] material;
   public bool isDissolving = false;
   public float speed;
   public float dissolve;

      
    void Start()
    {
        // resets dissolve effect to zero
        foreach (var matts in material)
            {
                matts.SetFloat("_DissolveCutoff",0);
            }
    }

    // Update is called once per frame
    void Update()
    {
        // if draculas bur animation is playing, start dissolve effect
        if (gameObject.GetComponent<AnimationTestScript>().deadFireAnim == true)
            isDissolving = true;

        if (isDissolving)
        {
            dissolve += speed * Time.deltaTime;
            //Animating cutout
            foreach (var matts in material)
            {
                matts.SetFloat("_DissolveCutoff", dissolve);
            }
            // Activating particle systems
            foreach (var item in particles)
            {
               item.gameObject.SetActive(true);
            }
        }
    }
}
