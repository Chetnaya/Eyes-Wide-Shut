using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class shelterDoor : Interactable
{
    [SerializeField]
    private GameObject door;
    private bool doorOpen;

    public GameObject dialogue01;
    public GameObject dialogue02;

    // Start is called before the first frame update
    void Start()
    {
        // Disable Dialogue 02 object initially
        dialogue02.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Design interaction using code
    protected override void Interact()
    {
        doorOpen = !doorOpen;
        door.GetComponent<Animator>().SetBool("IsOpen", doorOpen);

        // Disable Dialogue 01 and enable Dialogue 02 when the door is opened
        if (doorOpen)
        {
            dialogue01.SetActive(false);
            dialogue02.SetActive(true);
        }
        // Disable Dialogue 02 and enable Dialogue 01 when the door is closed
        else
        {
            dialogue01.SetActive(true);
            dialogue02.SetActive(false);
        }
    }
}