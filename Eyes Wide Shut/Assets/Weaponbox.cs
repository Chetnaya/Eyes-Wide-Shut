using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weaponbox : Interactable
{
    //Gameobjects that are to be diabled
    public GameObject promtText;
    public GameObject Arrow;
    public GameObject dialoguebox8;

    //Gameobjects to be enabled
    public GameObject instructionPanel;
    
    protected override void Interact()
    {
        //Disabling
        promtText.SetActive(false);
        Arrow.SetActive(false);
        dialoguebox8.SetActive(false);

        //Enabling
        instructionPanel.SetActive(true);

    }
}
