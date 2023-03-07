using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchBox2 : Interactable
{
    // Array of light components attached to switch 1
    public Light[] switch2Lights;

    // Variable to keep track of whether the lights are on or off
    private bool isLightOn = false;
    
    public GameObject dialogue02;
    public GameObject dialogue03;

    void Start()
    {
        dialogue03.SetActive(false);
    }

    // Override the base Interact() method to toggle the light intensity
    protected override void Interact()
    {
        if (!isLightOn)
        {
            // Turn on the lights for switch 1
            foreach (Light lightComponent in switch2Lights)
            {
                lightComponent.intensity = 1.59f;
            }
            isLightOn = true;
            dialogue02.SetActive(false);
            dialogue03.SetActive(true);
        }
        else
        {
            // Turn off the lights for switch 1
            foreach (Light lightComponent in switch2Lights)
            {
                lightComponent.intensity = 0f;
            }
            isLightOn = false;
            dialogue02.SetActive(true);
            dialogue03.SetActive(false);
        }
    }
}
