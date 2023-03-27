using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SwitchBox1 : Interactable
{
    // Array of light components attached to switch 1
    public Light[] switch1Lights;

    // Variable to keep track of whether the lights are on or off
    private bool isLightOn = false;

    public GameObject switchPointerImage;
    public GameObject boxPointerImage;
    public Arrow arrowimage;
    
    public AudioSource SwitchOnSound;



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

            //Enable switch pointer 
            switchPointerImage.SetActive(false);
            boxPointerImage.SetActive(true);

            
            //Set target object for arrow at index 3
            arrowimage.objectiveIndex = 4;

            SwitchOnSound.Play();

        }
        else
        {
            // Turn off the lights for switch 1
            foreach (Light lightComponent in switch1Lights)
            {
                lightComponent.intensity = 0f;
            }
            isLightOn = false;

            //Disable switch pointer
            switchPointerImage.SetActive(true);

            //Enable box pointer Image
            boxPointerImage.SetActive(false);

            //Set target object for arrow at index 4(weapon box)
            arrowimage.objectiveIndex = 3;

            SwitchOnSound.Play();
        }
    }
}
