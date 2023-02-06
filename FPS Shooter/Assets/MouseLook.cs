using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float mouseSensitivity = 100f;
    
    //To set a refrence to the player body that we want to move
    public Transform playerBody;

    float xRotation = 0f;

    void Start()
    {
        //Hides and lock the cursor to the centre of the screen
        Cursor.lockState = CursorLockMode.Locked; 
    }

    void Update()
    {
        //Get "Mouse X" inputs from input manager in unity and multiplies it with mouse sensitivity
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        
        //Get "Mouse X" inputs from input manager in unity and multiplies it with mouse sensitivity
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        //Decreases X-Rotation based on Mouse Y
        xRotation -= mouseY ;

        //Makes sure that the player wont rotate above the given range
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        //Rotates Player body around the X-Axis
        transform.localRotation =  Quaternion.Euler(xRotation, 0f, 0f);

        //Rotates Player body around the Y-Axis
        playerBody.Rotate(Vector3.up * mouseX);
    }
}
