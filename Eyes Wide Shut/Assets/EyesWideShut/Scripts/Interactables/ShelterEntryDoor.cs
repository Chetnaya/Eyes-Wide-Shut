using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShelterEntryDoor : Interactable
{
    public GameObject EntryDoor;
    private bool isOpen;

    protected override void Interact()
    {
        isOpen = !isOpen;
        EntryDoor.GetComponent<Animator>().SetBool("S.DoorIsOpen", isOpen);
    }
}
