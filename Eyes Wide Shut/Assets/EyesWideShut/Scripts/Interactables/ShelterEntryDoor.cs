using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShelterEntryDoor : Interactable
{
    public GameObject EntryDoor;
    private bool isOpen;
    public GameObject PointerImage;

    public Arrow arrowScript;

    protected override void Interact()
    {
        isOpen = !isOpen;
        EntryDoor.GetComponent<Animator>().SetBool("S.DoorIsOpen", isOpen);

        if(isOpen)
        {
            //Disable Pointer
            PointerImage.SetActive(false);
            arrowScript.objectiveIndex = 1;

            //Door open sound
        }
        else
        {
            //Enable Pointer
            PointerImage.SetActive(true);
           

            //Door close sound
        }

       
    }
}
