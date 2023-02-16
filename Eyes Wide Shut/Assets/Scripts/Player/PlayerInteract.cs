using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    private Camera cam;

    [SerializeField]
    private float distance = 3f;
    [SerializeField]
    private LayerMask mask;

    private PlayerUI playerUI;

    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponent<PlayerLook>().cam;
        playerUI = GetComponent<PlayerUI>();
    }

    // Update is called once per frame
    void Update()
    {
        playerUI.UpdateText(string.Empty);
        //Creates a ray at the centre of the camera , shooting outwards.
        //new Ray(First part is the origin, and the Direction)
        Ray ray = new Ray(cam.transform.position, cam.transform.forward );
        Debug.DrawRay(ray.origin, ray.direction * distance);

        //Variable to store our RayCast hit or our collision info
        RaycastHit hitInfo ;
        //To check if we have actually hit anything
        if (Physics.Raycast(ray, out hitInfo, distance, mask))
        {
            if(hitInfo.collider.GetComponent<Interactable>()!= null)
            {
                playerUI.UpdateText(hitInfo.collider.GetComponent<Interactable>().promtMessage);
            }
        }
    }
}
