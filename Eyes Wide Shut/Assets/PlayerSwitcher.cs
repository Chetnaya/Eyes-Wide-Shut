using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSwitcher : MonoBehaviour
{
    public GameObject player1;
    public GameObject player2;

    public GameObject gunPrefab; // Reference to the gun prefab
    private GameObject gunInstance; // Instance of the gun in the scene

    public int currentPlayerIndex = 0;

    void Start()
    {
        player2.transform.position = player1.transform.position;
        player2.transform.rotation = player1.transform.rotation;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            currentPlayerIndex = (currentPlayerIndex + 1) % 2;
            if (currentPlayerIndex == 0)
            {
                // Switching to player 1, find and destroy the gun instance
                gunInstance = FindObjectOfType<GunScript>().gameObject;
                Destroy(gunInstance);
            }

            player1.SetActive(currentPlayerIndex == 0);
            player2.SetActive(currentPlayerIndex == 1);

            if (currentPlayerIndex == 1 && gunInstance == null)
            {
                // Switching to player 2, instantiate the gun prefab
                gunInstance = Instantiate(gunPrefab, player2.transform);
            }
        }
    }
}


