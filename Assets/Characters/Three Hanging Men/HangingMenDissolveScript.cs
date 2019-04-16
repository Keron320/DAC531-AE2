using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HangingMenDissolveScript : MonoBehaviour
{
   public ParticleSystem[] particles;
   public Material[] material;
    bool isDissolving = false;
    public float speed;

    float dissolve;
        
        private void Start() 
        {
            // resets dissolve effect to zero
            foreach (var matts in material)
                {
                    matts.SetFloat("_DissolveCutoff",0);
                }
        }

        void OnTriggerEnter(Collider col)
        {
                if (col.transform.tag == "Player")
                isDissolving = true;
        }

        // Update is called once per frame
        void Update()
        {
            if (isDissolving)
            {
                dissolve += speed * Time.deltaTime;
                //Animating cutout
                foreach (var matts in material)
                {
                    matts.SetFloat("_DissolveCutoff", dissolve);
                }
                foreach (var item in particles)
                {
                    item.gameObject.SetActive(true);
                }
            }
        }
}
