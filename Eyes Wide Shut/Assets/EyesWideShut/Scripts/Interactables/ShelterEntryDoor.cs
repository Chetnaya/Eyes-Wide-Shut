using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShelterEntryDoor : Interactable
{
    public GameObject EntryDoor;
    private bool isOpen;
    public GameObject PointerImage;

    protected override void Interact()
    {
        isOpen = !isOpen;
        EntryDoor.GetComponent<Animator>().SetBool("S.DoorIsOpen", isOpen);

        if(isOpen)
        {
            //Disable Pointer
            PointerImage.SetActive(false);

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
