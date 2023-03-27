using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weaponbox : Interactable
{
    public GameObject player1;
    public GameObject player2;
    
    protected override void Interact()
    {
        player1.SetActive(false);
        player2.SetActive(true);
    }
}
