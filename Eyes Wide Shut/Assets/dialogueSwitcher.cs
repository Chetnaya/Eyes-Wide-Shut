using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class dialogueSwitcher : MonoBehaviour
{
    public GameObject dialogue01;
    public GameObject dialogue02;
    public GameObject dialogue03;
    public GameObject dialogue04;

    public BoxCollider collider01;
    public BoxCollider collider02;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (other.gameObject == collider01.gameObject)
            {
                dialogue01.SetActive(false);
                dialogue02.SetActive(true);
                collider01.enabled = false;
            }
            else if (other.gameObject == collider02.gameObject)
            {
                dialogue03.SetActive(false);
                dialogue04.SetActive(false);
                collider02.enabled = false;
            }
        }
    }
}
