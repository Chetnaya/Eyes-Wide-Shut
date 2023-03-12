using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class shelterDoor : Interactable
{
    [SerializeField]
    private GameObject door;
    private bool doorOpen;

    [SerializeField]
    private AudioSource doorOpenSound;

    [SerializeField]
    private AudioSource doorCloseSound;

    void Start()
    {
        doorOpenSound = doorOpenSound .GetComponent<AudioSource>();
        doorCloseSound = doorCloseSound.GetComponent<AudioSource>();
    }

    protected override void Interact()
    {
        doorOpen = !doorOpen;
        door.GetComponent<Animator>().SetBool("IsOpen", doorOpen);

        if (doorOpen)
        {
            doorOpenSound.Play();
        }
        else
        {
            doorCloseSound.Play();
        }
    }
}