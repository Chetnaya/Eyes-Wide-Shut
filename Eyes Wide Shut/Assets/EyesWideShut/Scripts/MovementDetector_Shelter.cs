using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementDetector_Shelter : MonoBehaviour
{
    /*-----------------------------------------------------------
   -------------GAME OBJECTS TO BE DISABLED---------------------
   -------------------------------------------------------------*/
    public GameObject dialogue09;
    public GameObject RestrictedAreaCollider;
    public BoxCollider MovementDetectorCollider;
    /*-----------------------------------------------------------
    --------------REFERENCE FROM OTHER SCRIPT---------------------
    -------------------------------------------------------------*/
    public Arrow arrowimage;  
    /*-------------------------------------------------------------
    -----------FUNCTION TO DETECT COLLISION FROM THE PLAYER--------
    -------------------------------------------------------------*/
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //Disabling
            dialogue09.SetActive(false);
            RestrictedAreaCollider.SetActive(false);
            MovementDetectorCollider.enabled = false;
            //Making the arrow point towards the tower(index = 6)
            arrowimage.objectiveIndex = 6;
        }
    }
}

