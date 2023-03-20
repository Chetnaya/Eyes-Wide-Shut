using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lieutenant : Interactable
{
    // bool dialogue04Enabled = false;
    public GameObject dialogue04;
    public GameObject dialogue03;
    // public GameObject dialogue05;

    // Start is called before the first frame update
    void Start()
    {
        dialogue04.SetActive(false);
        // dialogue05.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
    // {
    //     if (!dialogue04.activeSelf && !dialogue05.activeSelf)
    //     {
    //         dialogue05.SetActive(true);
    //     }
    }
    
    protected override void Interact()
    {
        dialogue03.SetActive(false);
        dialogue04.SetActive(true);


        // dialogue03.SetActive(false);
        // if (!dialogue04Enabled)
        // {
        //     dialogue04.SetActive(true);
        //     dialogue04Enabled = true;
        // } 
        // else 
        // {
        //     dialogue05.SetActive(true);
        // }
    }
}
