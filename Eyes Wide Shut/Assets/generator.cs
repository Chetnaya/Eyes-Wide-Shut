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

    public GameObject generatorobject;

    public GameObject generatorPointerImage;
    public GameObject CentreDoorPointerImage;

    public Arrow arrowimage;

    void Start()
    {
        GeneratorSound = GeneratorSound.GetComponent<AudioSource>();
    }

     protected override void Interact()
    {
        //Generator's box collider will disable
        generatorobject.GetComponent<BoxCollider>().enabled = false;

        //Generator's Pointer image will disable
        generatorPointerImage.SetActive(false);

        //Main Centre's pointer image will enable
        CentreDoorPointerImage.SetActive(true);

        //set target object for arrow at index 2
        arrowimage.objectiveIndex = 2;


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
