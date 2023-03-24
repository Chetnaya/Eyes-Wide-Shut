using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class generator : Interactable
{
    public Light[] StreetLights;

    private bool lightison = false;
    public AudioSource GeneratorSound;

    void Start()
    {
        GeneratorSound = GeneratorSound.GetComponent<AudioSource>();
    }

    protected override void Interact()
    {
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
            // Turn off the lights for switch 1
            foreach (Light lightComponent in StreetLights)
            {
                lightComponent.intensity = 0f;
            }
            lightison = false;
        }
    }

}
