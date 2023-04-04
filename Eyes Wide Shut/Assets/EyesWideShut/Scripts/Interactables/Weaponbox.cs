using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weaponbox : Interactable
{
    //-----------------------------
    //GAME OBJECTS TO BE DISABLED
    //-----------------------------
    public GameObject promtText;
    public GameObject Arrow;
    public GameObject dialoguebox8;

    //-----------------------------
    //GAME OBJECTS TO BE ENABLED
    //-----------------------------
    public GameObject instructionPanel;
    public GameObject dialoguebox9;
    public GameObject gun;
    //Players
    public GameObject player01;
    public GameObject player02;
    //Audio
    public AudioSource WeaponInstructions;
    //-----------------------------

    void Start()
    {
        WeaponInstructions = WeaponInstructions.GetComponent<AudioSource>();
    }

    protected override void Interact()
    {
        //Disabling
        dialoguebox8.SetActive(false);

        //Enabling
        instructionPanel.SetActive(true);

        //Playing the AudioSource
        WeaponInstructions.Play();

    }

    //Instruction Panel Button Functionality
    public void GunDisplay()
    {
        //Gun will be active
        gun.SetActive(true);
        
        dialoguebox9.SetActive(true);
        instructionPanel.SetActive(false);
    }
}
