using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeGlassCrate : Interactable
{
    [SerializeField]
    private GameObject EyeGlassCreate;
    private bool CrateIsOpen;

    public GameObject eyeGlass;

    [SerializeField]
    private AudioSource crateOpenSound;

    [SerializeField]
    private AudioSource crateCloseSound;

    // Start is called before the first frame update
    void Start()
    {
        doorOpenSound = crateOpenSound .GetComponent<AudioSource>();
        crateCloseSound = crateCloseSound.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    
    protected override void Interact()
    {
        CrateIsOpen = !CrateIsOpen;
        EyeGlassCreate.GetComponent<Animator>().SetBool("CrateIsOpen", CrateIsOpen);

        if(!CrateIsOpen)
        {
            eyeGlass.GetComponent<BoxCollider>().enabled = false;
            //Disable the box collider of eye glass
        }
        else
        {
            eyeGlass.GetComponent<BoxCollider>().enabled = true;
            //Enable the box collider of eye glass
        }

        if (CrateIsOpen)
        {
            crateCloseSound.Play();
        }
        else
        {
            crateCloseSound.Play();
        }
    }
}
