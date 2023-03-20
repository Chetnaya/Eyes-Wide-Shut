using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collider02 : MonoBehaviour
{
    public GameObject dialogue05;
    public GameObject dialogue02;

    public GameObject dialoguebox4;
    public BoxCollider collider02;

    // void Start()
    // {
    //     dialogue02.SetActive(false);
    // }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            dialoguebox4.SetActive(false);
            dialogue05.SetActive(true);

            dialogue02.SetActive(false);
            collider02.enabled = false;
        }
    }
}
