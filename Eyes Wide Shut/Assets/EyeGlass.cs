using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeGlass : Interactable
{
    public GameObject dialogue05;
    public GameObject EyeGlassPanel;
    
    protected override void Interact()
    {
        EyeGlassPanel.SetActive(true);
        dialogue05.SetActive(false);

    }
}
