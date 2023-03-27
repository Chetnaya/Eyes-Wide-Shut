using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : Interactable
{
    [SerializeField]
    private GameObject door;
    private bool doorOpen;

    public GameObject smokeEffect;
    public GameObject doorPointerImage;
    public GameObject switchPointerImage;

    [SerializeField]
    private AudioSource doorOpenSound;

    [SerializeField]
    private AudioSource doorCloseSound;

    public Arrow arrow;

    void Start()
    {
        doorOpenSound = doorOpenSound .GetComponent<AudioSource>();
        doorCloseSound = doorCloseSound.GetComponent<AudioSource>();
    }



    //Design interaction using code
    protected override void Interact()
    {
        doorOpen = !doorOpen;
        door.GetComponent<Animator>().SetBool("IsOpen", doorOpen);

        //Disable smoke
        smokeEffect.SetActive(false);

        //Entry door pointer disable
        doorPointerImage.SetActive(false);

        //Switch pointer enable
        switchPointerImage.SetActive(true);

        //Set target object for arrow at index 3
        arrow.objectiveIndex = 3;

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
