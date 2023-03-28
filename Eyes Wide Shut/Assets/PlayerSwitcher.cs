using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSwitcher : MonoBehaviour
{
    public GameObject player1;
    public GameObject player2;
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
            player1.SetActive(currentPlayerIndex == 0);
            player2.SetActive(currentPlayerIndex == 1);
        }
    }
}

// {
//     public GameObject player1;
//     public GameObject player2;

//     private GameObject activePlayer;

//     void Start()
//     {
//         // Set the initial active player to player1
//         activePlayer = player1;

//         // Ensure that both players have the same position
//         player2.transform.position = player1.transform.position;
//     }

//     void Update()
//     {
//         if (Input.GetKeyDown(KeyCode.Tab))
//         {
//             // Switch the active player
//             if (activePlayer == player1)
//             {
//                 activePlayer = player2;
//                 // player2.SetActive(true);
//                 // player1.SetActive(false);
//             }
//             else
//             {
//                 activePlayer = player1;
//                 // player2.SetActive(false);
//                 // player1.SetActive(true);
//             }

//             // Update the camera positions to match the active player
//             player1.transform.GetChild(0).gameObject.SetActive(activePlayer == player1);
//             player2.transform.GetChild(0).gameObject.SetActive(activePlayer == player2);
//         }
//     }
// }