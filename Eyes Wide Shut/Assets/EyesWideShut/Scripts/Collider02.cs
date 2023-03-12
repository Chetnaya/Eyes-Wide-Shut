using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collider02 : MonoBehaviour
{
    public GameObject dialogue02;
    public GameObject dialogue03;
    public BoxCollider collider02;

    // void Start()
    // {
    //     dialogue02.SetActive(false);
    // }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            dialogue02.SetActive(false);
            dialogue03.SetActive(false);
            collider02.enabled = false;
        }
    }
}
