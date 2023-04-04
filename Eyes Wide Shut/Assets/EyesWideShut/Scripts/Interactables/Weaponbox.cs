using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// A Child class of Interactable class
public class Weaponbox : Interactable
{
   /*-----------------------------------------------------------
   -------------GAME OBJECTS TO BE DISABLED---------------------
   -------------------------------------------------------------*/
    public GameObject promtText;
    public GameObject Arrow;
    public GameObject dialoguebox8;
    /*-----------------------------------------------------------
    -------------GAME OBJECTS TO BE ENABLED---------------------
    -------------------------------------------------------------*/
    public GameObject instructionPanel;
    public GameObject dialoguebox9;
    public GameObject gun;
    /*-----------------------------------------------------------
    ----------------AUDIO SOURCE GAME OBJECT---------------------
    -------------------------------------------------------------*/
    public AudioSource WeaponInstructions;
    /*-------------------------------------------------------------
    -----Start is called on the frame when a script is enabled-----
    just before any of the Update methods is called the first time
    ---------------------------------------------------------------*/
    void Start()
    {
        WeaponInstructions = WeaponInstructions.GetComponent<AudioSource>();
    }
    /*-------------------------------------------------------------
    Overrides the Interact() method from the base class Interactable.
    -------------------------------------------------------------*/
    protected override void Interact()
    {
        //Disabling
        dialoguebox8.SetActive(false);

        //Enabling
        instructionPanel.SetActive(true);

        //Playing the AudioSource
        WeaponInstructions.Play();

    }
    /*------------------------------------------------------------
    -----------Instruction Panel Button Functionality-------------
    -------------------------------------------------------------*/
    public void GunDisplay()
    {
        //Gun will be active
        gun.SetActive(true);
        
        dialoguebox9.SetActive(true);
        instructionPanel.SetActive(false);
    }
}
