using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAlarm : MonoBehaviour
{
    public float speed = 10.0f; // adjust the speed of rotation

    // Update is called once per frame
    void Update()
    {
        // Rotate the cylinder around its center
        
        transform.Rotate(Vector3.forward *  speed * Time.deltaTime);
    }
}
