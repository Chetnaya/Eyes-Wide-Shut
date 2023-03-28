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
    private Vector3 lastPlayerPosition;

    void Start()
    {
        lastPlayerPosition = player1.transform.position;
        // player2.transform.position = player1.transform.position;
        // player2.transform.rotation = player1.transform.rotation;
        player2.transform.localScale = new Vector3(0.52f, 0.82f, 0.52f);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (currentPlayerIndex == 1)
            {
                // Save the last player position before switching to Player 1
                lastPlayerPosition = player2.transform.position;
            }

            currentPlayerIndex = (currentPlayerIndex + 1) % 2;
            if (currentPlayerIndex == 0)
            {
                // Switching to player 1, find and destroy the gun instance
                gunInstance = FindObjectOfType<GunScript>().gameObject;
                Destroy(gunInstance);
            }
            player1.SetActive(currentPlayerIndex == 0);
            player2.SetActive(currentPlayerIndex == 1);

            if (currentPlayerIndex == 0)
            {
                // Switching to player 1, set the position to the last player position
                player1.transform.position = lastPlayerPosition;
                player1.transform.rotation = player2.transform.rotation;
            }

            if (currentPlayerIndex == 1 && gunInstance == null)
            {
                // Switching to player 2, instantiate the gun prefab
                gunInstance = Instantiate(gunPrefab, player2.transform);
            }
            //Scaling the player2
            if (currentPlayerIndex == 1)
            {
                player2.transform.localScale = new Vector3(0.52f, 0.82f, 0.52f);
            }

            player2.transform.position = player1.transform.position;
            player2.transform.rotation = player1.transform.rotation;

            player2.transform.localScale = new Vector3(0.52f, 0.82f, 0.52f);
        }
    }
}
// {
//     public GameObject player1;
//     public GameObject player2;
//     public GameObject gunPrefab; // Reference to the gun prefab
//     private GameObject gunInstance; // Instance of the gun in the scene
//     public int currentPlayerIndex = 0;

//     private Vector3 player1StartPosition; // Store the starting position of player 1

//     void Start()
//     {
//         player1StartPosition = player1.transform.position;
//         player2.transform.position = player1StartPosition;
//         player2.transform.rotation = player1.transform.rotation;
//     }

//     void Update()
//     {
//         if (Input.GetKeyDown(KeyCode.Tab))
//         {
//             currentPlayerIndex = (currentPlayerIndex + 1) % 2;
//             if (currentPlayerIndex == 0)
//             {
//                 // Switching to player 1, find and destroy the gun instance
//                 gunInstance = FindObjectOfType<GunScript>().gameObject;
//                 Destroy(gunInstance);
//             }
//             player1.SetActive(currentPlayerIndex == 0);
//             player2.SetActive(currentPlayerIndex == 1);
//             if (currentPlayerIndex == 1 && gunInstance == null)
//             {
//                 // Switching to player 2, instantiate the gun prefab
//                 gunInstance = Instantiate(gunPrefab, player2.transform);
//             }
//             // Update the position and rotation of player1 and player2
//             if (currentPlayerIndex == 0)
//             {
//                 player1.transform.position = player2.transform.position;
//                 player1.transform.rotation = player2.transform.rotation;
//             }
//             else
//             {
//                 player2.transform.position = player1.transform.position;
//                 player2.transform.rotation = player1.transform.rotation;
//             }
//         }
//     }
// }



