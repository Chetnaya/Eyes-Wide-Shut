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
    public GameObject weaponboxPointerImage;
    /*-----------------------------------------------------------
    -------------GAME OBJECTS TO BE ENABLED---------------------
    -------------------------------------------------------------*/
    public GameObject instructionPanel;
    public GameObject dialoguebox9;
    public GameObject gun;
    public GameObject ExitDoorPointerCanvas;
    public GameObject MovementDetector_Shelter;
    /*-----------------------------------------------------------
    --------------REFERENCE FROM OTHER SCRIPT---------------------
    -------------------------------------------------------------*/
    public Arrow arrowimage;
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
        //Disabling and enabling
        dialoguebox8.SetActive(false);
        instructionPanel.SetActive(true);
        MovementDetector_Shelter.SetActive(true);

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

        weaponboxPointerImage.SetActive(false);
        ExitDoorPointerCanvas.SetActive(true);
        arrowimage.objectiveIndex = 5;
    }
}
