using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lieutenant : Interactable
{
    public GameObject dialogue04;
    public GameObject dialogue03;

    // Start is called before the first frame update
    void Start()
    {
        dialogue04.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    protected override void Interact()
    {
        dialogue03.SetActive(false);
        dialogue04.SetActive(true);
    }
}
