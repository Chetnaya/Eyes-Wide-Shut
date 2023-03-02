using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SwitchBox1 : Interactable
{
    // Array of light components attached to switch 1
    public Light[] switch1Lights;

    // Variable to keep track of whether the lights are on or off
    private bool isLightOn = false;

    // Override the base Interact() method to toggle the light intensity
    protected override void Interact()
    {
        if (!isLightOn)
        {
            // Turn on the lights for switch 1
            foreach (Light lightComponent in switch1Lights)
            {
                lightComponent.intensity = 1.59f;
            }
            isLightOn = true;
        }
        else
        {
            // Turn off the lights for switch 1
            foreach (Light lightComponent in switch1Lights)
            {
                lightComponent.intensity = 0f;
            }
            isLightOn = false;
        }
    }
}
