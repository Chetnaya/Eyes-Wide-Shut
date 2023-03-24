using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShelterEntryDoor : Interactable
{
    public GameObject EntryDoor;
    private bool isOpen;
    public GameObject ShelterDoorPointerImage;
    public GameObject MainCentreDoorPointerImage;

    public AudioSource SlideOpenSound;


    public Arrow arrowScript;

    protected override void Interact()
    {
        isOpen = !isOpen;
        EntryDoor.GetComponent<Animator>().SetBool("S.DoorIsOpen", isOpen);

        if(isOpen)
        {
            //Disable Pointer
            ShelterDoorPointerImage.SetActive(false);
            MainCentreDoorPointerImage.SetActive(true);


            arrowScript.objectiveIndex = 1;

            //Door open sound
            SlideOpenSound.Play();

        }
        else
        {
            //Enable Pointer
            ShelterDoorPointerImage.SetActive(true);
            MainCentreDoorPointerImage.SetActive(false);

            //Door close sound
            SlideOpenSound.Play();
        }

       
    }
}
