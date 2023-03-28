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
        promtText.SetActive(false);
        Arrow.SetActive(false);
        dialoguebox8.SetActive(false);

        //Enabling
        instructionPanel.SetActive(true);

        //Playing the AudioSource
        WeaponInstructions.Play();

    }

    //Instruction Panel Button Functionality
    public void PlayersSwitch()
    {
        player01.SetActive(false);
        player02.SetActive(true);

        dialoguebox9.SetActive(true);

        instructionPanel.SetActive(false);
    }
}
