using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collider01 : MonoBehaviour
{
    public GameObject dialogue01;
    public GameObject dialogue02;
    public BoxCollider collider01;

    void Start()
    {
        dialogue02.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            dialogue01.SetActive(false);
            dialogue02.SetActive(true);
            collider01.enabled = false;
        }
    }
}