using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    private Camera cam;

    [SerializeField]
    private float distance = 3f;

    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponent<PlayerLook>().cam;
    }

    // Update is called once per frame
    void Update()
    {
        //Creates a ray at the centre of the camera , shooting outwards.
        //new Ray(First part is the origin, and the Direction)
        Ray ray = new Ray(cam.transform.position, cam.transform.forward );
        Debug.DrawRay(ray.origin, ray.direction * distance);
    }
}
