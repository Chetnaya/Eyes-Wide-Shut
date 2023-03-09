using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class dialogueSwitcher : MonoBehaviour
{
    public GameObject dialogue01;
    public GameObject dialogue02;

    private BoxCollider collider;

    private void Start()
    {
        collider = GetComponent<BoxCollider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // dialogue01.enabled = false;
            // dialogue02.enabled = true;
            dialogue01.SetActive(false);
            dialogue02.SetActive(true);

            collider.enabled = false;
        }
        
    }
}
