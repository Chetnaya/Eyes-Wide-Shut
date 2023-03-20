using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeGlassCrate : Interactable
{
    [SerializeField]
    private GameObject EyeGlassCreate;
    private bool CrateIsOpen;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    
    protected override void Interact()
    {
        CrateIsOpen = !CrateIsOpen;
        EyeGlassCreate.GetComponent<Animator>().SetBool("CrateIsOpen", CrateIsOpen);
    }
}
