using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class generator : Interactable
{
    public Light[] StreetLights;

    private bool lightison = false;
    public AudioSource GeneratorSound;

    public GameObject dialogue06;
    public GameObject dialogue07;

    void Start()
    {
        GeneratorSound = GeneratorSound.GetComponent<AudioSource>();
    }

     protected override void Interact()
    {
        dialogue07.SetActive(true);
        dialogue06.SetActive(false);


        //Lights are off
        if (!lightison)
        {
            // Turn on the lights for switch 1
            foreach (Light lightComponent in StreetLights)
            {
                lightComponent.intensity = 1.2f;
            }
            lightison = true;
            
            GeneratorSound.Play();

            
        }
        else
        {
            //Lights are on
            foreach (Light lightComponent in StreetLights)
            {
                lightComponent.intensity = 0f;
            }
            lightison = false;

            

        }
    }

}
