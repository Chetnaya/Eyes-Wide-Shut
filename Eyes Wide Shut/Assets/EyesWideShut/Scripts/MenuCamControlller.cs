using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuCamControlller : MonoBehaviour
{
    public Transform currentMount;
    // public var currentMount : Transform;
    public float speedFactor = 0.1f;
    // public var speedFactor : float = 0.1;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, currentMount.position,speedFactor );
        transform.rotation = Quaternion.Slerp(transform.rotation, currentMount.rotation, speedFactor);
    }
    
    public void setMount( Transform newMount)
    {
        currentMount = newMount;
    }
}
