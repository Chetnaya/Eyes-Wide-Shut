using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class light : Interactable
{
    // Reference to the light component attached to the switch box
    public Light lightComponent;

    // Variable to keep track of whether the light is on or off
    private bool isLightOn = false;

    // Override the base Interact() method to turn the light on and off
    protected override void Interact()
    {
        if (!isLightOn)
        {
            // Turn on the light
            lightComponent.intensity = 2f;
            isLightOn = true;
        }
        else
        {
            // Turn off the light
            lightComponent.intensity = 0f;
            isLightOn = false;
        }
    }
}
    
// } this script, we add a public lightIntensity variable that can be set in the Inspector. In the Interact method, we retrieve the Light component attached to the game object and toggle its enabled property as before. However, we now also set the intensity property of the light to either the lightIntensity value or 0f, depending on whether the light is enabled. This allows the player to adjust the intensity of the light source by modifying the lightIntensity variable in the Inspector.




